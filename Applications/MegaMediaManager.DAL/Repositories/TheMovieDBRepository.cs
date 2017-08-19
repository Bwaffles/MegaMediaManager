using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MegaMediaManager.Model;
using System.Linq.Expressions;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;

using System.Net.Http;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace MegaMediaManager.DAL
{
    public class TheMovieDBRepository
    {
        private static readonly Uri baseAddress = new Uri("http://api.themoviedb.org/3/");
        private static readonly string apiKey = "a0e9a2a4bf20414f55c0f3c1b0910ec9";
        private readonly HttpClient httpClient = new HttpClient { BaseAddress = baseAddress };

        public async Task<HttpResponseMessage> GetResponse(string requestUri)
        {
            var response = await httpClient.GetAsync(requestUri);
            if (!response.IsSuccessStatusCode)
            {
                Thread.Sleep(response.Headers.RetryAfter.Delta.Value.Milliseconds + 1); //wait this many seconds then try again
                response = await GetResponse(requestUri);
            }
            return response;
        }

        public async Task<JObject> GetData(string requestUri)
        {
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

            using (var response = await GetResponse(requestUri))
            {
                var responseDataStr = await response.Content.ReadAsStringAsync();
                var data = (JObject)JsonConvert.DeserializeObject(responseDataStr);

                return data;
            }
        }

        public async Task<Person> FindPersonById(int id)
        {
            string requestUri = "person/" + id + "?api_key=" + apiKey + "&append_to_response=external_ids";
            var data = await GetData(requestUri) as JObject;

            if (!CheckStatus(data))
                return null;

            JsonSerializerSettings jss = new JsonSerializerSettings
            {

            };
            ValidateDate(ref data, "birthday", "deathday");
            var person = JsonConvert.DeserializeObject<Person>(JsonConvert.SerializeObject(data));
            var altName = JsonConvert.DeserializeObject<List<string>>(JsonConvert.SerializeObject(data["also_known_as"]));

            await AddPerson(person, altName);

            return DataContextFactory.GetDataContext().Person.Find(person.Id);
        }

        private static void ValidateDate(ref JObject data, params string[] key)
        {
            foreach (var k in key)
            {
                DateTime tmp;
                if (data[k].ToString() != "null" && data[k].ToString() != string.Empty && !DateTime.TryParse(data[k].ToString(), out tmp))
                {
                    data[k] = data[k] + "-01-01";
                }
            }
        }

        private async Task AddPerson(Person person, List<string> altNames)
        {
            using (new EFUnitOfWorkFactory().Create())
            {
                var context = DataContextFactory.GetDataContext();

                context.Person.AddOrUpdate(p => p.Id, person);

                foreach (var an in altNames)
                {
                    if (await context.AlternativeName.FindAsync(person.Id, an) == null)
                    {
                        context.AlternativeName.Add(new AlternativeName { PersonId = person.Id, Name = an });
                    }
                }
            }
        }

        public bool CheckStatus(JObject data)
        {
            var statusCode = data["status_code"];
            if (statusCode == null)
                return true; //Not sure when this happens

            switch (int.Parse(statusCode.ToString()))
            {
                case 1: return true; //Success
                case 25: return false; //Your request count (#) is over the allowed limit of (40).
                case 34: return false; //The resource you requested could not be found.
            }

            return true;
        }

        public async Task<Movie> FindMovieById(int id)
        {
            string requestUri = "movie/" + id + "?api_key=" + apiKey + "&append_to_response=keywords,credits";
            var data = await GetData(requestUri);

            if (!CheckStatus(data))
                return null;

            var keywords = JsonConvert.DeserializeObject<List<Keyword>>(data["keywords"]["keywords"].ToString());
            var castCredit = JsonConvert.DeserializeObject<List<Credit>>(data["credits"]["cast"].ToString());
            var crewCredit = JsonConvert.DeserializeObject<List<Credit>>(data["credits"]["crew"].ToString());
            var genres = JsonConvert.DeserializeObject<List<Genre>>(data["genres"].ToString());
            var movie = JsonConvert.DeserializeObject<Movie>(JsonConvert.SerializeObject(data));

            var origLangCode = data["original_language"].ToString();
            var origLang = movie.SpokenLanguages.Single(x => x.LanguageCode == origLangCode);
            origLang.OriginalLanguage = true;

            await AddMovieAsync(movie, genres, keywords, castCredit, crewCredit);

            return await DataContextFactory.GetDataContext().Movie.FindAsync(movie.Id);
        }

        public async Task AddMovieAsync(Movie entity, List<Genre> genres, List<Keyword> keywords, List<Credit> castCredit, List<Credit> crewCredit)
        {
            //Add persons first because they need API calls to populate and it will kill the context
            var context = DataContextFactory.GetDataContext();
            foreach (var cr in crewCredit)
            {
                var person = await context.Person.FindAsync(cr.PersonId);
                if (person == null)
                    await FindPersonById(cr.PersonId);
            }
            foreach (var cr in castCredit)
            {
                var person = await context.Person.FindAsync(cr.PersonId);
                if (person == null)
                    await FindPersonById(cr.PersonId);
            }

            using (new EFUnitOfWorkFactory().Create())
            {
                context = DataContextFactory.GetDataContext();
                context.Movie.AddOrUpdate(m => m.Id, entity);

                foreach (var gen in genres)
                {
                    context.Genre.AddOrUpdate(g => g.Id, gen);
                    context.MovieGenre.AddOrUpdate(new MovieGenre { MovieId = entity.Id, GenreId = gen.Id });
                }

                foreach (var key in keywords)
                {
                    context.Keyword.AddOrUpdate(k => k.Id, key);
                    context.MovieKeyword.AddOrUpdate(new MovieKeyword { MovieId = entity.Id, KeywordId = key.Id });
                }

                foreach (var cr in crewCredit)
                {
                    var dept = await context.Department.FindAsync(cr.DepartmentName);
                    if (dept == null)
                    {
                        dept = new Department { Name = cr.DepartmentName };
                        context.Department.AddOrUpdate(d => d.Name, dept);
                    }
                    var job = await context.Job.FindAsync(cr.JobName);
                    if (job == null)
                        context.Job.AddOrUpdate(j => j.Name, new Job { Name = cr.JobName, Department = dept, DepartmentName = dept.Name });
                    cr.MovieId = entity.Id;
                    cr.CreditType = CreditType.Crew;
                    context.Credit.AddOrUpdate(c => c.CreditId, cr);
                }

                foreach (var ca in castCredit)
                {
                    ca.DepartmentName = "Actors";
                    var dept = await context.Department.FindAsync(ca.DepartmentName) as Department;
                    if (dept == null)
                    {
                        dept = new Department { Name = ca.DepartmentName };
                        context.Department.AddOrUpdate(d => d.Name, dept);
                    }
                    ca.JobName = "Actor";
                    var job = await context.Job.FindAsync(ca.JobName) as Job;
                    if (job == null)
                        context.Job.AddOrUpdate(j => j.Name, new Job { Name = ca.JobName, Department = dept, DepartmentName = dept.Name });
                    ca.MovieId = entity.Id;
                    ca.CreditType = CreditType.Cast;
                    context.Credit.AddOrUpdate(c => c.CreditId, ca);
                }
            }
        }
        
    }
}

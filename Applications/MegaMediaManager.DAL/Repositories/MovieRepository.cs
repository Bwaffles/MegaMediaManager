using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
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
    public class MovieRepository
    {
        //public async Task<ICollection<Movie>> GetMovieByTitle(string title)
        //{
        //    IQueryable<Movie> items = DataContextFactory.GetDataContext().Set<Movie>();
        //    var t = DataContextFactory.GetDataContext().Movie.Select(m => m.Title.Contains(title));
        //}

        //public async Task<ICollection<Movie>> GetMovieByTitleAPI(string title)
        //{
            //using (httpClient)
            //{
            //    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

            //    using (var response = await httpClient.GetAsync("search/movie?query=" + title + "&api_key=" + apiKey))
            //    {
            //        var responseDataStr = await response.Content.ReadAsStringAsync();
            //        //responseDataStr = responseDataStr.Remove(responseDataStr.IndexOf("\"keywords\":{"), 12);
            //        //responseDataStr = responseDataStr.Remove(responseDataStr.Length - 1, 1);

            //        var movies = JObject.Parse(responseDataStr)["results"]
            //            .ToObject<ICollection<Movie>>();

            //        //var movie = JsonConvert.DeserializeObject<Movie>(responseDataStr);

            //        //if (movie.Status == null)
            //        //    movie.Status = new Status { Name = "Released" };

            //        return movies;
            //    }
            //}
        //}

        public async Task<Movie> FindById(int id)
        {
            var t = await DataContextFactory.GetDataContext().Movie.FindAsync(id);
            if (t == null)
                return await new TheMovieDBRepository().FindMovieById(id);
            else
                return t;
        }

        public Movie FindById(int id, params Expression<Func<Movie, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(x => x.Id == id);
        }
        /// <summary>
        /// Returns an IQueryable of all items of type T.
        /// </summary>
        /// <param name="includeProperties">An expression of additional properties to eager load. For example: x => x.SomeCollection, x => x.SomeOtherCollection.</param>
        /// <returns>An IQueryable of the requested type T.</returns>
        public IQueryable<Movie> FindAll(params Expression<Func<Movie, object>>[] includeProperties)
        {
            IQueryable<Movie> items = DataContextFactory.GetDataContext().Movie;

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        /// <summary>
        /// Returns an IQueryable of items of type T.
        /// </summary>
        /// <param name="predicate">A predicate to limit the items being returned.</param>
        /// <param name="includeProperties">An expression of additional properties to eager load. For example: x => x.SomeCollection, x => x.SomeOtherCollection.</param>
        /// <returns>An IEnumerable of the requested type T.</returns>
        public IEnumerable<Movie> FindAll(Expression<Func<Movie, bool>> predicate, params Expression<Func<Movie, object>>[] includeProperties)
        {
            IQueryable<Movie> items = DataContextFactory.GetDataContext().Movie;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.Where(predicate);
        }

        /// <summary>
        /// Removes an entity from the underlying DbContext.
        /// </summary>
        /// <param name="entity">The entity that should be removed.</param>
        public void Remove(Movie entity)
        {
            DataContextFactory.GetDataContext().Set<Movie>().Remove(entity);
        }

        /// <summary>
        /// Removes an entity from the underlying DbContext. Calls <see cref="FindById" /> to resolve the item.
        /// </summary>
        /// <param name="id">The ID of the entity that should be removed.</param>
        //public virtual void Remove(int id)
        //{
        //    Remove(FindById(id));
        //}

        /// <summary>
        /// Disposes the underlying data context.
        /// </summary>
        public void Dispose()
        {
            if (DataContextFactory.GetDataContext() != null)
            {
                DataContextFactory.GetDataContext().Dispose();
            }
        }
    }
}

using System.Data.Entity;
using System.Collections.Generic;
using MegaMediaManager.Model;

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Serialization;


namespace MegaMediaManager.DAL
{
    public class MyDropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<MegaMediaManagerContext>
    {
        protected override void Seed(MegaMediaManagerContext context)
        {
            //var users = new List<User>
            //{
            //    new User{ UserName = "Tannis", Email = "tannis@test.com", PasswordHash="123456"},
            //    new User{ UserName = "jsmith", Email = "jsmith@test.com", PasswordHash="654321"},
            //    new User{ UserName = "qbarret", Email = "qbarret@test.com", PasswordHash="111111"},
            //    new User{ UserName = "pflips", Email = "pflips@test.com", PasswordHash="333555"}
            //};
            //foreach (var user in users) context.Users.AddFromAPI(user);

            //context.Language.AddFromAPI(new Language { Code = "en", Name = "English" });

            //var movies = new List<Movie>
            //{
            //    //new Movie{ Title = "Fight Club" },
            //    new Movie{ Title = "Jurassic Park" },
            //    new Movie{ Title = "Star Wars" },
            //    new Movie{ Title = "Deadpool" }
            //};
            //context.Movie.AddRange(movies);
            //context.SaveChanges();

            //var userMovies = new List<UserMovie>
            //{
            //    new UserMovie{ UserId = users[0].Id, MovieId = 2, Hype = 10},
            //    new UserMovie{ UserId =users[0].Id, MovieId = 3, Hype = 10},
            //    new UserMovie{ UserId = users[1].Id, MovieId = 3, Hype = 1},
            //    new UserMovie{ UserId = users[2].Id, MovieId = 1, Hype = 3},
            //    new UserMovie{ UserId = users[3].Id, MovieId = 3, Hype = 7}
            //};
            //context.UserMovie.AddRange(userMovies);
            //context.SaveChanges();

            //var userMovieWatches = new List<UserMovieWatch>
            //{
            //    new UserMovieWatch{ UserMovieId = 1, WatchNum = 1},
            //    new UserMovieWatch{ UserMovieId = 1, WatchNum = 2},
            //    new UserMovieWatch{ UserMovieId = 1, WatchNum = 3},
            //    new UserMovieWatch{ UserMovieId = 2, WatchNum = 1},
            //    new UserMovieWatch{ UserMovieId = 3, WatchNum = 1},
            //    new UserMovieWatch{ UserMovieId = 4, WatchNum = 1},
            //    new UserMovieWatch{ UserMovieId = 5, WatchNum = 1}
            //};
            //context.UserMovieWatch.AddRange(userMovieWatches);
            //context.SaveChanges();

            //var ratingTypes = new List<ReviewType>
            //{
            //    new ReviewType{ Code = "Overall", Description="This is what you rate the movie overall", AdvancedFlag=false },
            //    new ReviewType{ Code = "Enjoyment", Description="How much you enjoyed this movie, even if you know it kind of sucks.", AdvancedFlag=false },
            //    new ReviewType{ Code = "Ending", Description="This is how you felt about the ending", AdvancedFlag=false },
            //};
            //context.ReviewType.AddRange(ratingTypes);
            //context.SaveChanges();

            //var userMovieWatchRatings = new List<UserMovieWatchReview>
            //{
            //    new UserMovieWatchReview{ ReviewId = ratingTypes[0].Code, UserMovieWatchId = 1 },
            //    new UserMovieWatchReview{ ReviewId = "Ending", Rating = 8, UserMovieWatchId = 1  },
            //    new UserMovieWatchReview{ ReviewId = "Enjoyment", Rating = 9, UserMovieWatchId = 1  },
            //    new UserMovieWatchReview{ ReviewId = "Enjoyment", Rating = 5, UserMovieWatchId = 2  },
            //};
            //context.UserMovieWatchReview.AddRange(userMovieWatchRatings);
            //context.SaveChanges();
        }
    }
}

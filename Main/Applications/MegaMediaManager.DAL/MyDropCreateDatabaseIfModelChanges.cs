﻿using System.Data.Entity;
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
        //static async Task Sample()
        //{
        //    var baseAddress = new Uri("http://api.themoviedb.org/3/");

        //    using (var httpClient = new HttpClient { BaseAddress = baseAddress })
        //    {

        //        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

        //        using (var response = await httpClient.GetAsync("search/movie?query=Fight Club&api_key=a0e9a2a4bf20414f55c0f3c1b0910ec9"))
        //        {

        //            var responseData = await response.Content.ReadAsStreamAsync();
        //            var serializer = new DataContractJsonSerializer(typeof(Movie));
        //            var movie = (List<Movie>)serializer.ReadObject(responseData);
        //        }
        //    }
        //}
        protected override void Seed(MegaMediaManagerContext context)
        {
            // var s = Sample();

            var users = new List<User>
            {
                new User{ UserName = "Tannis", Email = "tannis@test.com", PasswordHash="123456"},
                new User{ UserName = "jsmith", Email = "jsmith@test.com", PasswordHash="654321"},
                new User{ UserName = "qbarret", Email = "qbarret@test.com", PasswordHash="111111"},
                new User{ UserName = "pflips", Email = "pflips@test.com", PasswordHash="333555"}
            };
            foreach (var user in users) context.Users.Add(user);

            var movies = new List<Movie>
            {
                new Movie{ Title = "Fight Club" },
                new Movie{ Title = "Jurassic Park" },
                new Movie{ Title = "Star Wars" },
                new Movie{ Title = "Deadpool" }
            };
            context.Movie.AddRange(movies);
            context.SaveChanges();

            var userMovies = new List<UserMovie>
            {
                new UserMovie{ UserId = users[0].Id, MovieId = 2, Hype = 10, Comment = "This is the best movie ever"},
                new UserMovie{ UserId =users[0].Id, MovieId = 3, Hype = 10, Comment = "Can't wait to see this"},
                new UserMovie{ UserId = users[1].Id, MovieId = 3, Hype = 1, Comment = "" },
                new UserMovie{ UserId = users[2].Id, MovieId = 1, Hype = 3, Comment = "" },
                new UserMovie{ UserId = users[3].Id, MovieId = 3, Hype = 7, Comment = "" }
            };
            context.UserMovie.AddRange(userMovies);
            context.SaveChanges();

            var userMovieWatches = new List<UserMovieWatch>
            {
                new UserMovieWatch{ UserMovieId = 1, WatchNum = 1, Comment = "Wow that was amazing..."},
                new UserMovieWatch{ UserMovieId = 1, WatchNum = 2, Comment = "Still amazing!"},
                new UserMovieWatch{ UserMovieId = 1, WatchNum = 3, Comment = "This movie never gets worse!"},
                new UserMovieWatch{ UserMovieId = 2, WatchNum = 1, Comment = ""},
                new UserMovieWatch{ UserMovieId = 3, WatchNum = 1, Comment = ""},
                new UserMovieWatch{ UserMovieId = 4, WatchNum = 1, Comment = ""},
                new UserMovieWatch{ UserMovieId = 5, WatchNum = 1, Comment = ""}
            };
            context.UserMovieWatch.AddRange(userMovieWatches);
            context.SaveChanges();

            var ratingTypes = new List<ReviewType>
            {
                new ReviewType{ Code = "Overall", Description="This is what you rate the movie overall", AdvancedFlag="N" },
                new ReviewType{ Code = "Enjoyment", Description="How much you enjoyed this movie, even if you know it kind of sucks.", AdvancedFlag="N" },
                new ReviewType{ Code = "Ending", Description="This is how you felt about the ending", AdvancedFlag="N" },
            };
            context.RatingType.AddRange(ratingTypes);
            context.SaveChanges();

            var userMovieWatchRatings = new List<UserMovieWatchReview>
            {
                new UserMovieWatchReview{ ReviewId = "Overall", Rating = 10, UserMovieWatchId = 1 },
                new UserMovieWatchReview{ ReviewId = "Ending", Rating = 8, UserMovieWatchId = 1  },
                new UserMovieWatchReview{ ReviewId = "Enjoyment", Rating = 9, UserMovieWatchId = 1  },
                new UserMovieWatchReview{ ReviewId = "Enjoyment", Rating = 5, UserMovieWatchId = 2  },
            };
            context.UserMovieWatchRating.AddRange(userMovieWatchRatings);
            context.SaveChanges();
        }
    }
}
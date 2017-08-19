using FluentAssertions;
using MegaMediaManager.DAL;
using MegaMediaManager.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace MegaMediaManager.Tests.Integration
{
    [TestClass]
    public class MegaMediaManagerContextTests : IntegrationTestBase
    {
        [TestMethod]
        public void CanAddUserUsingMegaMediaManagerContext()
        {
            using (new EFUnitOfWorkFactory().Create())
            {
                var context = DataContextFactory.GetDataContext();
                var user = new User { UserName = "joe", Email = "tannis@test.com", PasswordHash = "123456" };
                context.Users.Add(user);
                context.Users.Remove(user);
            }
        }

        [TestMethod]
        public void CanExecuteQueryAgainstDataContext()
        {
            using (var uow = new EFUnitOfWorkFactory().Create())
            {
                var context = DataContextFactory.GetDataContext();
                string username = Guid.NewGuid().ToString().Substring(0, 10);
                var user = new User { UserName = username, Email = "tannis@test.com", PasswordHash = "123456" };
                context.Users.Add(user);
                uow.Commit(false);
                var personCheck = context.Users.SingleOrDefault(x => x.UserName == username);
                personCheck.Should().NotBeNull();
                context.Users.Remove(user);
            }
        }

        [TestMethod]
        public async Task CanFindPersonByIdAPI()
        {
            var context = DataContextFactory.GetDataContext();
            var movieRepo = new TheMovieDBRepository();
            int id = 1245;
            var m = await movieRepo.FindPersonById(id);
            m.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CanFindMovieByIdAPI()
        {
            var context = DataContextFactory.GetDataContext();
            var movieRepo = new MovieRepository();
            int id = 558;
                var m = await movieRepo.FindById(id);

                m.Should().NotBeNull();
                if (m.MovieGenres.Count > 0)
                    m.MovieGenres[0].Genre.Should().NotBeNull();
                if (m.MovieKeywords.Count > 0)
                    m.MovieKeywords[0].Keyword.Should().NotBeNull();
        }

        //[TestMethod]
        //public async Task CanMapMovieTable()
        //{
        //    using (new EFUnitOfWorkFactory().Create())
        //    {
        //        var context = DataContextFactory.GetDataContext();
        //        var movieRepo = new MovieRepository();
        //        var movies = await movieRepo.GetMovieByTitleAPI("Spider-man") as ICollection<Movie>;
        //        foreach (var movie in movies)
        //            context.Movie.AddOrUpdate(movie);

        //        context.SaveChanges();

        //        //var m = context.Movie.SingleOrDefault(x => x.Id == movies.Id);
        //        //m.Should().NotBeNull();
        //    }
        //}
    }
}

using MegaMediaManager.Contracts.DTO;
using MegaMediaManager.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MegaMediaManager.DAL
{
    public class MovieRepository : Repository<Movie>
    {
        public void Add(MovieDTO movieDTO)
        {
            using (new EFUnitOfWorkFactory().Create())
            {
                var context = DataContextFactory.GetDataContext();
                var movie = new Movie();
                movie.Adult = movieDTO.Adult;
                movie.Title = movieDTO.Title;
                movie.Id = movieDTO.Id;
                context.Movie.Add(movie);
            }
        }

        //public async Task<ICollection<Movie>> GetMovieByTitle(string title)
        //{
        //    IQueryable<Movie> items = DataContextFactory.GetDataContext().Set<Movie>();
        //    var t = DataContextFactory.GetDataContext().Movie.Select(m => m.Title.Contains(title));
        //}

        public async Task<Movie> FindById(int id)
        {
            var t = await DataContextFactory.GetDataContext().Movie.FindAsync(id);
            if (t == null)
                return await new TheMovieDBRepository().FindMovieById(id);
            else
                return t;
        }
    }
}

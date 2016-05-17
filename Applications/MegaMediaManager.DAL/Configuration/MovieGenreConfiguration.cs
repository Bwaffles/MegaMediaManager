using MegaMediaManager.Model;
using System.Data.Entity.ModelConfiguration;

namespace MegaMediaManager.DAL.TypeConfiguration
{
    public class MovieGenreConfiguration : EntityTypeConfiguration<MovieGenre>
    {
        public MovieGenreConfiguration()
        {
            this.ToTable("movie_genre_t");

            Property(a => a.GenreId).HasColumnName("genre_id");
            Property(a => a.MovieId).HasColumnName("movie_id");
            Property(a => a.DateCreated).HasColumnName("date_created");
            Property(a => a.DateModified).HasColumnName("date_modified");
        }
    }
}

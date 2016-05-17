using System.Data.Entity.ModelConfiguration;
using MegaMediaManager.Model;

namespace MegaMediaManager.DAL.TypeConfiguration
{
    public class UserMovieConfiguration : EntityTypeConfiguration<UserMovie>
    {
        public UserMovieConfiguration()
        {
            this.ToTable("user_movie_t");

            Property(a => a.Id).HasColumnName("id");
            Property(a => a.UserId).HasColumnName("user_id").IsRequired();
            Property(a => a.MovieId).HasColumnName("movie_id");
            Property(a => a.Hype).IsOptional().HasColumnName("hype");
            Property(a => a.DateCreated).HasColumnName("date_created");
            Property(a => a.DateModified).HasColumnName("date_modified");
        }
    }
}

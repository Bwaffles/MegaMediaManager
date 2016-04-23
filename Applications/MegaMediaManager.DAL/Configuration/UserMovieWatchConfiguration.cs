using System.Data.Entity.ModelConfiguration;
using MegaMediaManager.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMediaManager.DAL.Configuration
{
    public class UserMovieWatchConfiguration : EntityTypeConfiguration<UserMovieWatch>
    {
        public UserMovieWatchConfiguration()
        {
            ToTable("user_movie_watch_t");

            Property(a => a.Id).HasColumnName("id");
            Property(a => a.UserMovieId).HasColumnName("user_movie_id");
            Property(a => a.WatchNum).HasColumnName("watch_num");
            Property(a => a.ReviewTitle).HasColumnName("review_title");
        }
    }
}

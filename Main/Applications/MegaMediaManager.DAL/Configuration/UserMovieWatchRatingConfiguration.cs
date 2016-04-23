using System.Data.Entity.ModelConfiguration;
using MegaMediaManager.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMediaManager.DAL.Configuration
{
    public class UserMovieWatchRatingConfiguration : EntityTypeConfiguration<UserMovieWatchReview>
    {
        public UserMovieWatchRatingConfiguration()
        {
            ToTable("user_movie_watch_rating_t");

            Property(a => a.Id).HasColumnName("id");
            Property(a => a.UserMovieWatchId).HasColumnName("user_movie_watch_id");
            Property(a => a.ReviewId).HasColumnName("rating_type_id");
            Property(a => a.Rating).HasColumnName("rating");
        }
    }
}

using System.Data.Entity.ModelConfiguration;
using MegaMediaManager.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMediaManager.DAL.TypeConfiguration
{
    public class UserMovieWatchReviewConfiguration : EntityTypeConfiguration<UserMovieWatchReview>
    {
        public UserMovieWatchReviewConfiguration()
        { 
            ToTable("user_movie_watch_review_t");

            Property(a => a.Id).HasColumnName("id");
            Property(a => a.UserMovieWatchId).HasColumnName("user_movie_watch_id");
            Property(a => a.Description).HasColumnName("description");
            Property(a => a.Rating).HasColumnName("rating");
            Property(a => a.ReviewTypeCode).HasColumnName("review_type_cd");
            Property(a => a.DateCreated).HasColumnName("date_created");
            Property(a => a.DateModified).HasColumnName("date_modified");
        }
    }
}

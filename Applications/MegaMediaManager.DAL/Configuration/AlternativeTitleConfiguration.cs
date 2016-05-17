using MegaMediaManager.Model;
using System.Data.Entity.ModelConfiguration;

namespace MegaMediaManager.DAL.TypeConfiguration
{
    public class AlternativeTitleConfiguration : EntityTypeConfiguration<AlternativeTitle>
    {
        public AlternativeTitleConfiguration()
        {
            this.ToTable("alternative_title_t");

            Property(a => a.MovieId).HasColumnName("movie_id");
            Property(a => a.Title).HasColumnName("title");
            Property(a => a.DateCreated).HasColumnName("date_created");
            Property(a => a.DateModified).HasColumnName("date_modified");
        }
    }
}

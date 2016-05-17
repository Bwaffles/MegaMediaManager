using MegaMediaManager.Model;
using System.Data.Entity.ModelConfiguration;

namespace MegaMediaManager.DAL.TypeConfiguration
{
    public class SpokenLanguageConfiguration : EntityTypeConfiguration<SpokenLanguage>
    {
        public SpokenLanguageConfiguration()
        {
            this.ToTable("spoken_language_t");

            Property(a => a.OriginalLanguage).HasColumnName("original_language_flag");
            Property(a => a.MovieId).HasColumnName("movie_id");
            Property(a => a.LanguageCode).HasColumnName("language_cd");
            Property(a => a.DateCreated).HasColumnName("date_created");
            Property(a => a.DateModified).HasColumnName("date_modified");
        }
    }
}

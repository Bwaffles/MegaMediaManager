using MegaMediaManager.Model;
using System.Data.Entity.ModelConfiguration;

namespace MegaMediaManager.DAL.TypeConfiguration
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            this.ToTable("genre_t");

            Property(a => a.Id).HasColumnName("id");
            Property(a => a.Name).HasColumnName("name");
            Property(a => a.DateCreated).HasColumnName("date_created");
            Property(a => a.DateModified).HasColumnName("date_modified");
        }
    }
}

using MegaMediaManager.Model;
using System.Data.Entity.ModelConfiguration;

namespace MegaMediaManager.DAL.TypeConfiguration
{
    public class KeywordConfiguration : EntityTypeConfiguration<Keyword>
    {
        public KeywordConfiguration()
        {
            this.ToTable("keyword_t");

            Property(a => a.Id).HasColumnName("id");
            Property(a => a.Name).HasColumnName("name");
            Property(a => a.DateCreated).HasColumnName("date_created");
            Property(a => a.DateModified).HasColumnName("date_modified");
        }
    }
}

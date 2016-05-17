using MegaMediaManager.Model;
using System.Data.Entity.ModelConfiguration;

namespace MegaMediaManager.DAL.TypeConfiguration
{
    public class AlternativeNameConfiguration : EntityTypeConfiguration<AlternativeName>
    {
        public AlternativeNameConfiguration()
        {
            this.ToTable("alternative_name_t");

            Property(a => a.PersonId).HasColumnName("person_id");
            Property(a => a.Name).HasColumnName("name");
            Property(a => a.DateCreated).HasColumnName("date_created");
            Property(a => a.DateModified).HasColumnName("date_modified");
        }
    }
}

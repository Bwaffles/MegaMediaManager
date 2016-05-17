using System.Data.Entity.ModelConfiguration;
using MegaMediaManager.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMediaManager.DAL.TypeConfiguration
{
    public class ReviewTypeConfiguration : EntityTypeConfiguration<ReviewType>
    {
        public ReviewTypeConfiguration()
        {
            ToTable("rating_type_r");

            Property(a => a.Code).HasColumnName("cd").HasMaxLength(20);
            Property(a => a.Description).HasColumnName("description").HasMaxLength(128);
            Property(a => a.AdvancedFlag).HasColumnName("advanced_flag").IsRequired();
            Property(a => a.DateCreated).HasColumnName("date_created");
            Property(a => a.DateModified).HasColumnName("date_modified");
        }
    }
}

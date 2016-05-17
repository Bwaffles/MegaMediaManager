using MegaMediaManager.Model;
using System.Data.Entity.ModelConfiguration;

namespace MegaMediaManager.DAL.Configuration
{
    public class StatusConfiguration : EntityTypeConfiguration<Status>
    {
        public StatusConfiguration()
        {
            this.ToTable("status_r");

            Property(a => a.Name).HasColumnName("name");
        }
    }
}

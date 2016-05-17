using System.Data.Entity.ModelConfiguration;
using MegaMediaManager.Model;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMediaManager.DAL.TypeConfiguration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.ToTable("user_t");

            Property(a => a.Id).HasColumnName("id");
            Property(a => a.UserName).IsRequired().HasColumnName("username");
            Property(a => a.PasswordHash).HasColumnName("password");
            Property(a => a.Email).IsOptional().HasColumnName("email");
            Property(a => a.AccessFailedCount).HasColumnName("access_failed_count");
            Property(a => a.EmailConfirmed).HasColumnName("email_confirmed");
            Property(a => a.LockoutEnabled).HasColumnName("lockout_enabled");
            Property(a => a.LockoutEndDateUtc).HasColumnName("lockout_end_dt");
            Property(a => a.PhoneNumber).HasColumnName("phone_number");
            Property(a => a.PhoneNumberConfirmed).HasColumnName("phone_number_confirmed");
            Property(a => a.TwoFactorEnabled).HasColumnName("two_factor_enabled");

            Property(a => a.DateCreated).HasColumnName("date_created");
            Property(a => a.DateModified).HasColumnName("date_modified");
        }
    }
}

using System.Data.Entity.ModelConfiguration;
using MegaMediaManager.Model;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMediaManager.DAL.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.ToTable("user_t");

            Property(a => a.Id).HasColumnName("id");
            Property(a => a.UserName).IsRequired().HasColumnName("username")
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("ix_username_uq") { IsUnique = true}));
            Property(a => a.PasswordHash).HasColumnName("password");
            Property(a => a.Email).IsOptional().HasColumnName("email");
        }
    }
}

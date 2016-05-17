using MegaMediaManager.Model;
using System.Data.Entity.ModelConfiguration;

namespace MegaMediaManager.DAL.TypeConfiguration
{
    public class CreditConfiguration : EntityTypeConfiguration<Credit>
    {
        public CreditConfiguration()
        {
            this.ToTable("credit_t");

            Property(a => a.CreditId).HasColumnName("credit_id");
            Property(a => a.DepartmentName).HasColumnName("department_name");
            Property(a => a.JobName).HasColumnName("job_name");
            Property(a => a.PersonId).HasColumnName("person_id");
            Property(a => a.ProfilePath).HasColumnName("profile_path");
            Property(a => a.Character).HasColumnName("character");
            Property(a => a.CreditType).HasColumnName("credit_type");
            Property(a => a.MovieId).HasColumnName("movie_id");
            Property(a => a.Order).HasColumnName("order");
            Property(a => a.DateCreated).HasColumnName("date_created");
            Property(a => a.DateModified).HasColumnName("date_modified");
        }
    }
}

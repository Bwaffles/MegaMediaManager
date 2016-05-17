using MegaMediaManager.Model;
using System.Data.Entity.ModelConfiguration;

namespace MegaMediaManager.DAL.TypeConfiguration
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            this.ToTable("person_t");

            Property(a => a.Id).HasColumnName("id");
            Property(a => a.Adult).HasColumnName("adult");
            Property(a => a.Biography).HasColumnName("biography");
            Property(a => a.Birthday).HasColumnName("birthday_dt");
            Property(a => a.Deathday).HasColumnName("deathday_dt");
            Property(a => a.Homepage).HasColumnName("homepage");
            Property(a => a.Name).HasColumnName("name");
            Property(a => a.PlaceOfBirth).HasColumnName("place_of_birth");
            Property(a => a.ProfilePath).HasColumnName("profile_path");
            Property(a => a.DateCreated).HasColumnName("date_created");
            Property(a => a.DateModified).HasColumnName("date_modified");
        }
    }
}

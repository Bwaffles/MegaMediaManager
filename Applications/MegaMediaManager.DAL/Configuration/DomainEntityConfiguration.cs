using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Infrastructure;

namespace MegaMediaManager.DAL.Configuration
{
    public class DomainEntityConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        public DomainEntityConfiguration()
        {
            //Property(a => (DomainEntity<T>)a).HasColumnName("id");
        }
    }
}

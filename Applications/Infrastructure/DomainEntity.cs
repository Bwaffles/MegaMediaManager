using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Infrastructure
{
    public abstract class DomainEntity<T> : IValidatableObject
    {
        /// <summary> 
        /// Gets or sets the unique ID of the entity in the underlying data store. 
        /// </summary> 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public T Id { get; set; }

        /// <summary> 
        /// Checks if the current domain entity has an identity. 
        /// </summary> 
        /// <returns>True if the domain entity is transient (i.e. has no identity yet),
        /// false otherwise.
        /// </returns> 
        public bool IsTransient()
        {
            return Id.Equals(default(T));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is DomainEntity<T>))
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var item = (DomainEntity<T>)obj;

            if (item.IsTransient() || IsTransient())
            {
                return false;
            }
            return item.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                return Id.GetHashCode() ^ 31;
            }
            return base.GetHashCode();
        }

        public static bool operator ==(DomainEntity<T> left, DomainEntity<T> right)
        {
            if (Equals(left, null))
                return (Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(DomainEntity<T> left, DomainEntity<T> right)
        {
            return !(left == right);
        }

        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);

        public IEnumerable<ValidationResult> Validate()
        {
            var validationErrors = new List<ValidationResult>();
            var ctx = new ValidationContext(this, null, null);
            Validator.TryValidateObject(this, ctx, validationErrors, true);
            return validationErrors;
        }
    }
}

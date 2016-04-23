using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure
{
    public abstract class ValueObject<T> : IEquatable<T>, IValidatableObject where T : ValueObject<T>
    {
        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);

        public IEnumerable<ValidationResult> Validate()
        {
            var validationErrors = new List<ValidationResult>();
            var ctx = new ValidationContext(this, null, null);
            Validator.TryValidateObject(this, ctx, validationErrors, true);
            return validationErrors;
        }

        private bool CheckValue(PropertyInfo p, T other)
        {
            var left = p.GetValue(this, null);
            var right = p.GetValue(other, null);
            if (left == null || right == null)
            {
                return false;
            }

            if (typeof(T).IsAssignableFrom(left.GetType()))
            {
                return ReferenceEquals(left, right);
            }
            return left.Equals(right);
        }

        public bool Equals(T other)
        {
            if ((object)other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            //compare all public properties 
            PropertyInfo[] publicProperties = GetType().GetProperties();

            if (publicProperties.Any())
            {
                return publicProperties.All(p => CheckValue(p, other));
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if ((object)obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;

            }
            var item = obj as ValueObject<T>;

            if ((object)item != null)
            {
                return Equals((T)item);
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = 31;
            bool changeMultiplier = false;
            int index = 1;

            PropertyInfo[] publicProperties = this.GetType().GetProperties();

            if (publicProperties.Any())
            {
                foreach (var item in publicProperties)
                {
                    object value = item.GetValue(this, null);

                    if ((object)value != null)
                    {
                        hashCode = hashCode * ((changeMultiplier) ? 59 : 114) + value.GetHashCode();
                        changeMultiplier = !changeMultiplier;
                    }
                    else
                    {
                        hashCode = hashCode ^ (index * 13);
                        //only for support {"a",null,null,"a"} <> {null,"a","a",null} 
                    }
                }
            }
            return hashCode;
        }

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            if (Equals(left, null))
            {
                return (Equals(right, null)) ? true : false;
            }
            return left.Equals(right);
        }

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !(left == right);
        }
    }
}

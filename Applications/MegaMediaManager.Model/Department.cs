using System;
using System.Collections.Generic;
using Infrastructure;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MegaMediaManager.Model
{
    public class Department : ValueObject<Department>, IDateTracking
    {
        [Key]
        public string Name { get; set; }

        [JsonIgnore]
        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        public DateTime DateModified { get; set; }
        

        public virtual ICollection<Job> Jobs { get; set; }

        #region Methods
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
        #endregion
    }
}

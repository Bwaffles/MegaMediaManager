using System;
using System.Collections.Generic;
using Infrastructure;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMediaManager.Model
{
    public class Job : ValueObject<Job>, IDateTracking
    {
        [Key]
        //[JsonProperty("job")]
        public string Name { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        [JsonIgnore]
        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        public DateTime DateModified { get; set; }
        

        public virtual Department Department { get; set; }

        #region Methods
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
        #endregion
    }
}

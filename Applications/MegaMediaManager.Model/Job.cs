using System;
using System.Collections.Generic;
using Infrastructure;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMediaManager.Model
{
    public class Job : ValueObject<Job>
    {
        [JsonProperty("job")]
        public string Name;

        public int DepartmentName;

        [ForeignKey("DepartmentName")]
        public Department Department;

        #region Methods
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
        #endregion
    }
}

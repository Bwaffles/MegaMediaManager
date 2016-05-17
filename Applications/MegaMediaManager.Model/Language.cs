using Infrastructure;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace MegaMediaManager.Model
{
    public class Language : ValueObject<Language>, IValidatableObject, IDateTracking
    {
        [JsonProperty("iso_639_1")]
        [Key]
        public string Code { get; set; } //ISO639-1

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonIgnore]
        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        public DateTime DateModified { get; set; }
        

        #region Navigation Properties
        public virtual ICollection<SpokenLanguage> SpokenLanguage { get; set; }
        #endregion

        #region Methods
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
        #endregion
    }
}

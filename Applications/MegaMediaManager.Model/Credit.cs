using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MegaMediaManager.Model
{
    public class Credit :DomainEntity<int>
    {
        //cast
        [JsonProperty("cast")]
        public Cast Cast;

        [JsonProperty("crew")]
        public Crew Crew;

        #region Methods
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
        #endregion
    }
}

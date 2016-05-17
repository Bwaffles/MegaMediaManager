using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MegaMediaManager.Model
{
    public class AlternativeTitle : ValueObject<AlternativeTitle>, IValidatableObject, IDateTracking
    {
        #region Foreign Keys
        [Key]
        [Column(Order=1)]
        public int MovieId { get; set; }
        #endregion

        [Key]
        [Column(Order = 2)]
        public string Title { get; set; }

        [JsonIgnore]
        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        public DateTime DateModified { get; set; }

        #region Navigation Properties
        public Movie Movie { get; set; }
        #endregion

        #region Methods
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
        #endregion
    }
}

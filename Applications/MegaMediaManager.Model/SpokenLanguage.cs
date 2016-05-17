using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure;
using Newtonsoft.Json;

namespace MegaMediaManager.Model
{
    public class SpokenLanguage : ValueObject<SpokenLanguage>, IValidatableObject, IDateTracking
    {
        #region Foreign Keys
        [Key]
        [Column(Order=1)]
        public int MovieId { get; set; }

        [Key]
        [Column(Order = 2)]
        [JsonProperty("iso_639_1")]
        public string LanguageCode { get; set; }
        #endregion

        public bool OriginalLanguage { get; set; }

        [JsonIgnore]
        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        public DateTime DateModified { get; set; }
        

        #region Navigation Properties
        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }
        public virtual Language Language { get; set; }
        #endregion

        #region Methods
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
        #endregion
    }
}

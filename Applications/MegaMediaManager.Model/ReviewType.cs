using System;
using System.Collections.Generic;
using Infrastructure;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MegaMediaManager.Model
{
    public class ReviewType : IDateTracking
    {
        [Key]
        public string Code { get; set; }

        public string Description { get; set; }

        public bool AdvancedFlag { get; set; }

        [JsonIgnore]
        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        public DateTime DateModified { get; set; }
        

        #region Navigation Properties
        public virtual ICollection<UserMovieWatchReview> UserMovieWatchRatings { get; set; }
        #endregion

        #region Methods
        //public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    yield break;
        //}
        #endregion
    }
}

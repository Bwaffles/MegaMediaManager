using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MegaMediaManager.Model
{
    public class UserMovieWatchReview : DomainEntity<int>, IDateTracking
    {
        #region Foreign Keys
        public string ReviewTypeCode { get; set; }

        public int UserMovieWatchId { get; set; }
        #endregion

        public string Description { get; set; }

        public int Rating { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
        

        #region Navigation Propertie
        public virtual ReviewType ReviewType { get; set; }

        public virtual UserMovieWatch UserMovieWatch { get; set; }
        #endregion

        #region Methods
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MegaMediaManager.Model
{
    public class UserMovieWatchReview : DomainEntity<int>
    {
        #region Foreign Keys
        public int UserMovieWatchId { get; set; }

        public int ReviewId { get; set; }
        #endregion
        
        #region Navigation Properties
        public virtual Review Review { get; set; }
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

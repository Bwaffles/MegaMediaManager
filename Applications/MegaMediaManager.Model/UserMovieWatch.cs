using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MegaMediaManager.Model
{
    public class UserMovieWatch : DomainEntity<int>, IDateTracking
    {
        #region Foreign Keys
        public int UserMovieId { get; set; }
        #endregion

        public int WatchNum { get; set; }

        public string ReviewTitle { get; set; 
        }
        //watch_dt

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
        

        #region Navigation Properties
        public virtual UserMovie UserMovie { get; set; }

        public virtual ICollection<UserMovieWatchReview> UserMovieWatchReviews { get; set; }
        #endregion

        #region Methods
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
        #endregion
    }
}

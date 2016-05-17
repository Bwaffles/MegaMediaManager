using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMediaManager.Model
{
    public class UserMovie : DomainEntity<int>, IDateTracking
    {
        #region Foreign Keys
        public string UserId { get; set; }

        public int MovieId { get; set; }
        #endregion

        [Range(1, 10)]
        public int Hype { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
        

        #region Navigation Properties
        public virtual User User { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual ICollection<UserMovieWatch> UserMovieWatches { get; set; }
        #endregion

        #region Methods
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
        #endregion
    }
}

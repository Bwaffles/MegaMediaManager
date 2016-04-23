using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MegaMediaManager.Model
{
    public class Review : DomainEntity<int>
    {
        #region Foreign Keys
        public string ReviewTypeCode { get; set; }
        #endregion

        public string Description { get; set; }

        public int Rating { get; set; }

        #region Navigation Properties
        public virtual ReviewType ReviewType { get; set; }
        public virtual UserMovieWatchReview UserMovieWatchReview { get; set; }
        #endregion
    }
}

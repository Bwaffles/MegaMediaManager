using Infrastructure;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MegaMediaManager.Model
{
    public class MovieKeyword : IDateTracking
    {
        [Key, Column(Order = 0)]
        public int MovieId { get; set; }

        [Key, Column(Order = 1)]
        public int KeywordId { get; set; }

        [JsonIgnore]
        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        public DateTime DateModified { get; set; }
        

        #region Navigation Properties
        public virtual Keyword Keyword { get; set; }
        public virtual Movie Movie { get; set; }
        #endregion
    }
}

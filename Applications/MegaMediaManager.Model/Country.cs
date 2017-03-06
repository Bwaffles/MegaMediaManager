using System;
using System.Collections.Generic;
using Infrastructure;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MegaMediaManager.Model
{
    public class Country : IDateTracking
    {
        [Key]
        public string Code { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        public DateTime DateModified { get; set; }
        
        #region Navigation Properties
        public virtual List<ProductionCountry> ProductionCountry { get; set; }
        
        //public virtual List<Certification> Certification { get; set; }
        #endregion
    }
}

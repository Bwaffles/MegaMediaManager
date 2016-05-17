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
    public class AlternativeName : IDateTracking
    {
        #region Foreign Keys
        [Key, Column(Order = 0)]
        [JsonIgnore]
        public int PersonId { get; set; }
        #endregion

        [Key, Column(Order = 1)]
        public string Name { get; set; }

        [JsonIgnore]
        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        public DateTime DateModified { get; set; }

        #region Navigation Properties
        public Person Person { get; set; }
        #endregion

        //#region Methods
        //public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    yield break;
        //}
        //#endregion
    }
}

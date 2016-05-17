using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MegaMediaManager.Model
{
    public class ProductionCompany : DomainEntity<int>, IDateTracking
    {
        //  "description": null,
        //  "headquarters": "San Francisco, California",
        //  "homepage": "http://www.lucasfilm.com",
        //  "id": 1,
        //  "logo_path": "/8rUnVMVZjlmQsJ45UGotD0Uznxj.png",
        //  "name": "Lucasfilm",
        //  "parent_company": null

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("headquarters")]
        public string HeadQuarters { get; set; }
        
        [JsonProperty("homepage")]
        public string Homepage { get; set; }

        [JsonProperty("logo_path")]
        public string LogoPath { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parent_company")]
        public int ParentCompanyId { get; set; }

        [JsonIgnore]
        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        public DateTime DateModified { get; set; }
        
        #region Navigation Properties
        [ForeignKey("ParentCompanyId")]
        public virtual ProductionCompany ParentCompany { get; set; }
        
        public virtual List<MovieProductionCompany> MovieProductionCompanies { get; set; }
        #endregion

        #region Methods
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
        #endregion
    }
}

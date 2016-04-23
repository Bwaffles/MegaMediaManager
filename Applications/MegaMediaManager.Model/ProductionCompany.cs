using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MegaMediaManager.Model
{
    public class ProductionCompany : DomainEntity<int>
    {
        [JsonProperty("description")]
        public string Description;

        [JsonProperty("headquarters")]
        public string HeadQuarters;
        
        [JsonProperty("homepage")]
        public string Homepage;

        [JsonProperty("logo_path")]
        public string LogoPath;

        [JsonProperty("name")]
        public string Name;

        //parent_company_id in db
        [JsonProperty("parent_company")]
        public int ParentCompanyId;

        #region Navigation Properties
        [JsonProperty("parent_company")]
        public ProductionCompany ParentCompany;
        #endregion

        #region Methods
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
        #endregion
    }
}

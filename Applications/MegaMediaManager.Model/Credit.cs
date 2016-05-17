using System;
using System.Collections.Generic;
using Infrastructure;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMediaManager.Model
{
    public class Credit : IDateTracking
    {
        /*
            "credit_id": "52fe4250c3a36847f80149ef",
            "profile_path": null
            "id": 7469, //person id
         * 
         * //UNIQUE
            "department": "Writing",
            "job": "Author",
         * 
         * //IGNORE
            "name": "Jim Uhls", //person name
         * 
         * -------------------------------------------------
            "credit_id": "52fe4250c3a36847f80149f3",
            "profile_path": "/iUiePUAQKN4GY6jorH9m23cbVli.jpg"
            "id": 819, //person id
         * 
         * //UNIQUE
            "character": "The Narrator",
            "order": 0,
         * 
         * //IGNORE
            "name": "Edward Norton", //person name
            "cast_id": 4, --ignore
         * 
         * 
         *   "credit_type": "cast",
             "department": "Actors",
             "job": "Actor",
         *   "media_type": "tv",
             "id": "5240760b5dbf5b0c2c0139db",
             "person": 
         */

        #region Foreign Keys
        [JsonProperty("department")]
        public string DepartmentName { get; set; }

        [JsonProperty("job")]
        public string JobName { get; set; }

        public int MovieId { get; set; }

        [JsonProperty("id")]
        public int PersonId { get; set; }
        #endregion

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonProperty("credit_id")]
        public string CreditId { get; set; }
        
        [JsonProperty("character")]
        public string Character { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }

        [JsonIgnore]
        public CreditType CreditType { get; set; }

        [JsonIgnore]
        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        public DateTime DateModified { get; set; }

        #region Navigation Property
        [ForeignKey("DepartmentName")]
        public virtual Department Department { get; set; }

        [ForeignKey("JobName")]
        public virtual Job Job { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Person Person { get; set; }
        #endregion

        //#region Methods
        //public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //}
        //#endregion
    }
}

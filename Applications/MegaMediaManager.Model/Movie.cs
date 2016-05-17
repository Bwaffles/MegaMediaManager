using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MegaMediaManager.Model
{
    public class Movie : DomainEntity<int>, IDateTracking
    {
        #region Foreign Keys

        #endregion

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("budget")]
        public double Budget { get; set; }

        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }
        
        [JsonProperty("original_title")]
        public string OriginalTitle{ get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        //[JsonProperty("release_date")]
        //public DateTime ReleaseDate { get; set; }

        [JsonProperty("revenue")]
        public double Revenue { get; set; }

        [JsonProperty("runtime")]
        public int Runtime { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("tagline")]
        public string Tagline { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage{ get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonIgnore]
        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        public DateTime DateModified { get; set; }
        
        #region Navigation Properties

        //[JsonProperty("vote_count")]
       // public virtual ICollection<ReleaseDate> ReleaseDates { get; set; }

        [JsonIgnore]
        public virtual List<Credit> Credits { get; set; }

        //[JsonProperty("keywords")]
        [JsonIgnore]
        public virtual List<MovieKeyword> MovieKeywords { get; set; }

        //[JsonProperty("genres")]
        [JsonIgnore]
        public virtual List<MovieGenre> MovieGenres { get; set; }

        [JsonProperty("spoken_languages")]
        public virtual ICollection<SpokenLanguage> SpokenLanguages { get; set; }

        //[JsonProperty("production_companies")]
        //public virtual ICollection<ProductionCompany> ProductionCompanies { get; set; }

        //[JsonProperty("production_countires")]
        //public virtual ICollection<ProductionCountry> ProductionCountries { get; set; }

        [JsonProperty("alternative_titles")]
        public virtual ICollection<AlternativeTitle> AlternativeTitles { get; set; }

        public virtual ICollection<UserMovie> UserMovies { get; set; }
        #endregion

        #region Methods
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
        #endregion
    }
}

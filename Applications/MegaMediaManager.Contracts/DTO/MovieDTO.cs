using System;
using System.Collections.Generic;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;

namespace MegaMediaManager.Contracts.DTO
{
    public class MovieDTO
    {
        //NO NEED// public AccountState AccountStates { get; set; }
        public bool Adult { get; set; }
        public List<AlternativeTitleDTO> AlternativeTitles { get; set; }
        public string BackdropPath { get; set; }
        public SearchCollectionDTO BelongsToCollection { get; set; }
        public long Budget { get; set; }
        //public ChangesContainer Changes { get; set; }
        //public Credits Credits { get; set; }
        public List<int> Genres { get; set; } //genres table will already be populated... just need the int id reference
        public string Homepage { get; set; }
        public int Id { get; set; }
        //public Images Images { get; set; }
        public string ImdbId { get; set; }
        public List<KeywordDTO> Keywords { get; set; } //there is no way to get all keywords, so we'll have to add them movie by movie
        //NO NEED// public SearchContainer<ListResult> Lists { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        //public List<ProductionCompany> ProductionCompanies { get; set; } //this is just a foreign key reference... should i do another call to get the company info and add that at the same time?
        public List<string> ProductionCountries { get; set; } //countries will already be populated... just need the code reference
        public DateTime? ReleaseDate { get; set; }
        //public ResultContainer<ReleaseDatesContainer> ReleaseDates { get; set; }
        //public Releases Releases { get; set; }
        public long Revenue { get; set; }
        //NO NEED// public SearchContainer<ReviewBase> Reviews { get; set; }
        public int? Runtime { get; set; }
        //NO NEED// public SearchContainer<SearchMovie> Similar { get; set; }
        public List<string> SpokenLanguages { get; set; } //languages will already be populated... just need the code reference
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public List<TranslationDTO> Translations { get; set; }
        //NO NEED// public bool Video { get; set; }
        //NO NEED// public ResultContainer<Video> Videos { get; set; }
        //NO NEED// public double VoteAverage { get; set; }
        //NO NEED// public int VoteCount { get; set; }
    }
}

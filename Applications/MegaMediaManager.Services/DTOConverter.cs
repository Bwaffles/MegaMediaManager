using Mapster;
using MegaMediaManager.Contracts.DTO;
using System.Collections.Generic;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using System;
using System.Linq;

namespace MegaMediaManager.Services
{
    public class DTOConverter
    {
        private MovieDTO movieDTO;

        public MovieDTO Convert(Movie movie)
        {
            movieDTO = new MovieDTO();
            movieDTO = TypeAdapter.Adapt<MovieDTO>(movie);

            ConvertAlternativeTitles(movie);
            ConvertSearchCollection(movie);

            ConvertProductionCountries(movie);
            ConvertGenres(movie);
            ConvertKeywords(movie);

            ConvertSpokenLanguages(movie);
            ConvertTranslations(movie);

            return movieDTO;
        }

        private void ConvertProductionCountries(Movie movie)
        {
            movieDTO.ProductionCountries = new List<string>(movie.ProductionCountries.Select(prodCountry => prodCountry.Iso_3166_1));
        }

        private void ConvertGenres(Movie movie)
        {
            movieDTO.Genres = new List<int>(movie.Genres.Select(genre => genre.Id));
        }

        private void ConvertKeywords(Movie movie)
        {
            movieDTO.Keywords = TypeAdapter.Adapt<List<KeywordDTO>>(movie.Keywords.Keywords);
        }

        private void ConvertSpokenLanguages(Movie movie)
        {
            movieDTO.SpokenLanguages = new List<string>(movie.SpokenLanguages.Select(lang => lang.Iso_639_1));
        }

        private void ConvertTranslations(Movie movie)
        {
            if (movie?.Translations == null) return;

            TypeAdapterConfig<TranslationWithCountry, TranslationDTO>
                            .ForType()
                            .Map(dest => dest.CountryCode, src => src.Iso_3166_1)
                            .Map(dest => dest.LanguageCode, src => src.Iso_639_1);
            movieDTO.Translations = TypeAdapter.Adapt<List<TranslationDTO>>(movie.Translations.Translations);
        }

        private void ConvertSearchCollection(Movie movie)
        {
            movieDTO.BelongsToCollection = TypeAdapter.Adapt<SearchCollectionDTO>(movie.BelongsToCollection);
        }

        private void ConvertAlternativeTitles(Movie movie)
        {
            if (movie?.AlternativeTitles == null) return;

            TypeAdapterConfig<AlternativeTitle, AlternativeTitleDTO>
                            .ForType()
                            .Map(dest => dest.CountryCode, src => src.Iso_3166_1);
            movieDTO.AlternativeTitles = TypeAdapter.Adapt<List<AlternativeTitleDTO>>(movie.AlternativeTitles.Titles);
        }
    }
}

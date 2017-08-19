using MegaMediaManager.Contracts.DTO;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;

namespace MegaMediaManager.Services
{
    public class TMDbService
    {
        private static readonly string apiKey = "a0e9a2a4bf20414f55c0f3c1b0910ec9";
        private TMDbClient client;
        private DTOConverter converter;

        public TMDbService()
        {
            client = new TMDbClient(apiKey)
            {
                MaxRetryCount = 5
            };

            converter = new DTOConverter();
        }

        //i think this thing needs to return a giant DTO of all the data needed to insert a movie into the database
        //whoever calls this can take the dtos and start passing them into the context
        public MovieDTO GetMovie(int id)
        {
            var movie = client.GetMovieAsync(id, MovieMethods.AlternativeTitles |
                                                 MovieMethods.Credits |
                                                 MovieMethods.Images |
                                                 MovieMethods.Keywords |
                                                 MovieMethods.ReleaseDates |
                                                 MovieMethods.Releases |
                                                 MovieMethods.Translations |
                                                 MovieMethods.Undefined).Result;
            
            return converter.Convert(movie);
        }
    }
}

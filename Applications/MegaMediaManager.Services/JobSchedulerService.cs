using MegaMediaManager.DAL;

namespace MegaMediaManager.Services
{
    public class JobSchedulerService
    {
        public void AddMovie(int id)
        {
            var movie = new TMDbService().GetMovie(id);
            new MovieRepository().Add(movie);
        }

        public void test()
        {
            for (int i = 5; i < 10; i++)
                AddMovie(i);
        }
    }
}

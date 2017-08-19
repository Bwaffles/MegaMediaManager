using MegaMediaManager.DAL;
using MegaMediaManager.Mvc.Models.Movie;
using MegaMediaManager.Services;
using System;
using System.Web.Mvc;

namespace MegaMediaManager.Mvc.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }

        // GET: Movie/Details/5
        public async System.Threading.Tasks.Task<ActionResult> Details(int id)
        {
            var movieRepo = new MovieRepository();
            var movie = await movieRepo.FindById(id);
            var movieDetail = new MovieDetail();
            movieDetail.Adult = movie.Adult;
            movieDetail.Id = movie.Id;
            movieDetail.Title = movie.Title;
            return View(movieDetail);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(CreateMovie movie, FormCollection collection)
        {
            try
            {
                var job = new JobSchedulerService();
                job.AddMovie(movie.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

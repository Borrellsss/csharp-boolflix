using csharp_boolflix.Data.FormModels;
using csharp_boolflix.Models.Repositories;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    [Authorize]
    public class TvShowController : Controller
    {
        DbTvShowRepository dbTvShowRepository;
        DbCategoryRepository dbCategoryRepository;
        DbActorRepository dbActorRepository;
        public TvShowController(DbTvShowRepository _dbTvShowRepository, DbCategoryRepository _dbCategoryRepository, DbActorRepository _dbActorRepository)
        {
            dbTvShowRepository = _dbTvShowRepository;
            dbCategoryRepository = _dbCategoryRepository;
            dbActorRepository = _dbActorRepository;
        }
        public IActionResult Index()
        {
            List<TvShow> tvShows = dbTvShowRepository.GetAll(false, false);
            return View(tvShows);
        }
        public IActionResult Details(int id)
        {
            TvShow tvShow = dbTvShowRepository.GetById(id, true, true);
            return View(tvShow);
        }
        public IActionResult Create()
        {
            FormTvShow formTvShow = new ();
            formTvShow.Categories = dbCategoryRepository.GetAll();
            formTvShow.SelectedCategories = new List<int>();
            formTvShow.Actors = dbActorRepository.GetAll();
            formTvShow.SelectedActors = new List<int>();
            return View(formTvShow);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FormTvShow formTvShow)
        {
            if (!ModelState.IsValid)
            {
                formTvShow.Actors = dbActorRepository.GetAll();
                formTvShow.Categories = dbCategoryRepository.GetAll();
                if (formTvShow.SelectedCategories == null)
                {
                    formTvShow.SelectedCategories = new List<int>();
                }
                if (formTvShow.SelectedActors == null)
                {
                    formTvShow.SelectedActors = new List<int>();
                }
                return View(formTvShow);
            }
            dbTvShowRepository.Create(formTvShow);
            TvShow createdTvShow = dbTvShowRepository.GetLast(false, false);
            return RedirectToAction("Details", new { id = createdTvShow.Id });
        }
        //public IActionResult Update(int id)
        //{
        //    FormMovie formMovie = new FormMovie();
        //    formMovie.Movie = dbMovieRepository.GetById(id, true, true);
        //    if (formMovie.Movie == null)
        //    {
        //        return NotFound();
        //    }
        //    formMovie.Categories = dbCategoryRepository.GetAll();
        //    formMovie.Actors = dbActorRepository.GetAll();
        //    formMovie.SelectedCategories = new List<int>();
        //    formMovie.SelectedActors = new List<int>();
        //    if (formMovie.Movie.Categories.Count() > 0)
        //    {
        //        foreach (Category category in formMovie.Movie.Categories)
        //        {
        //            formMovie.SelectedCategories.Add(category.Id);
        //        }
        //    }
        //    if (formMovie.Movie.Actors.Count() > 0)
        //    {
        //        foreach (Actor actor in formMovie.Movie.Actors)
        //        {
        //            formMovie.SelectedActors.Add(actor.Id);
        //        }
        //    }
        //    return View(formMovie);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Update(int id, FormMovie formMovie)
        //{
        //    Movie movieToUpdate = dbMovieRepository.GetById(id, true, true);
        //    if (movieToUpdate == null)
        //    {
        //        return NotFound();
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        formMovie.Movie = movieToUpdate;
        //        formMovie.Actors = dbActorRepository.GetAll();
        //        formMovie.Categories = dbCategoryRepository.GetAll();
        //        if (formMovie.SelectedCategories == null)
        //        {
        //            formMovie.SelectedCategories = new List<int>();
        //        }
        //        if (formMovie.SelectedActors == null)
        //        {
        //            formMovie.SelectedActors = new List<int>();
        //        }
        //        return View(formMovie);
        //    }
        //    dbMovieRepository.Update(movieToUpdate, formMovie);
        //    return RedirectToAction("Details", new { id = movieToUpdate.Id });
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            TvShow tvShowToDelete = dbTvShowRepository.GetById(id, false, false);
            if (tvShowToDelete == null)
            {
                return NotFound();
            }
            dbTvShowRepository.Delete(tvShowToDelete);
            return RedirectToAction("Index");
        }
    }
}

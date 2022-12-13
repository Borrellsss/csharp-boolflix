using csharp_boolflix.Data.FormModels;
using csharp_boolflix.Models;
using csharp_boolflix.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        DbMovieRepository dbMovieRepository;
        DbCategoryRepository dbCategoryRepository;
        DbActorRepository dbActorRepository;
        public MovieController(DbMovieRepository _dbMovieRepository, DbCategoryRepository _dbCategoryRepository, DbActorRepository _dbActorRepository)
        {
            dbMovieRepository = _dbMovieRepository;
            dbCategoryRepository = _dbCategoryRepository;
            dbActorRepository = _dbActorRepository;
        }
        public IActionResult Index()
        {
            List<Movie> movies = dbMovieRepository.GetAll(false, false);
            return View(movies);
        }
        public IActionResult Details(int id)
        {
            Movie movie = dbMovieRepository.GetById(id, true, true);
            return View(movie);
        }
        public IActionResult Create()
        {
            FormMovie formMovie = new FormMovie();
            formMovie.Categories = dbCategoryRepository.GetAll();
            formMovie.SelectedCategories = new List<int>();
            formMovie.Actors = dbActorRepository.GetAll();
            formMovie.SelectedActors = new List<int>();
            return View(formMovie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FormMovie formMovie)
        {
            if(!ModelState.IsValid)
            {
                formMovie.Actors = dbActorRepository.GetAll();
                formMovie.Categories = dbCategoryRepository.GetAll();
                if (formMovie.SelectedCategories == null)
                {
                    formMovie.SelectedCategories = new List<int>();
                }
                if (formMovie.SelectedActors == null)
                {
                    formMovie.SelectedActors = new List<int>();
                }
                return View(formMovie);
            }
            dbMovieRepository.Create(formMovie);
            Movie createdMovie = dbMovieRepository.GetLast(false, false);
            return RedirectToAction("Details", new { id = createdMovie.Id });
        }
        public IActionResult Update(int id)
        {
            FormMovie formMovie = new FormMovie();
            formMovie.Movie = dbMovieRepository.GetById(id, true, true);
            if (formMovie.Movie == null)
            {
                return NotFound();
            }
            formMovie.Categories = dbCategoryRepository.GetAll();
            formMovie.Actors = dbActorRepository.GetAll();
            formMovie.SelectedCategories = new List<int>();
            formMovie.SelectedActors = new List<int>();
            if(formMovie.Movie.Categories.Count() > 0)
            {
                foreach (Category category in formMovie.Movie.Categories)
                {
                    formMovie.SelectedCategories.Add(category.Id);
                }
            }
            if (formMovie.Movie.Actors.Count() > 0)
            {
                foreach (Actor actor in formMovie.Movie.Actors)
                {
                    formMovie.SelectedActors.Add(actor.Id);
                }
            }
            return View(formMovie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, FormMovie formMovie)
        {
            Movie movieToUpdate = dbMovieRepository.GetById(id, true, true);
            if (movieToUpdate == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                formMovie.Movie = movieToUpdate;
                formMovie.Actors = dbActorRepository.GetAll();
                formMovie.Categories = dbCategoryRepository.GetAll();
                if (formMovie.SelectedCategories == null)
                {
                    formMovie.SelectedCategories = new List<int>();
                }
                if (formMovie.SelectedActors == null)
                {
                    formMovie.SelectedActors = new List<int>();
                }
                return View(formMovie);
            }
            dbMovieRepository.Update(movieToUpdate, formMovie);
            return RedirectToAction("Details", new { id = movieToUpdate.Id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Movie movieToDelete = dbMovieRepository.GetById(id, false, false);
            if (movieToDelete == null)
            {
                return NotFound();
            }
            dbMovieRepository.Delete(movieToDelete);
            return RedirectToAction("Index");
        }
    }
}

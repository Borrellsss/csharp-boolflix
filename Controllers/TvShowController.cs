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
        DbSeasonRepository dbSeasonRepository;
        DbCategoryRepository dbCategoryRepository;
        DbActorRepository dbActorRepository;
        public TvShowController(DbTvShowRepository _dbTvShowRepository, DbSeasonRepository _dbSeasonRepository, DbCategoryRepository _dbCategoryRepository, DbActorRepository _dbActorRepository)
        {
            dbTvShowRepository = _dbTvShowRepository;
            dbSeasonRepository = _dbSeasonRepository;
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
            TvShow tvShow = dbTvShowRepository.GetById(id, true, true, true);
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
        public IActionResult Update(int id)
        {
            FormTvShow formTvShow = new FormTvShow();
            formTvShow.TvShow = dbTvShowRepository.GetById(id, true, true, false);
            if (formTvShow.TvShow == null)
            {
                return NotFound();
            }
            formTvShow.Categories = dbCategoryRepository.GetAll();
            formTvShow.Actors = dbActorRepository.GetAll();
            formTvShow.SelectedCategories = new List<int>();
            formTvShow.SelectedActors = new List<int>();
            if (formTvShow.TvShow.Categories.Count() > 0)
            {
                foreach (Category category in formTvShow.TvShow.Categories)
                {
                    formTvShow.SelectedCategories.Add(category.Id);
                }
            }
            if (formTvShow.TvShow.Actors.Count() > 0)
            {
                foreach (Actor actor in formTvShow.TvShow.Actors)
                {
                    formTvShow.SelectedActors.Add(actor.Id);
                }
            }
            return View(formTvShow);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, FormTvShow formTvShow)
        {
            TvShow tvShowToUpdate = dbTvShowRepository.GetById(id, true, true, true);
            if (tvShowToUpdate == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                formTvShow.TvShow = tvShowToUpdate;
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
            dbTvShowRepository.Update(tvShowToUpdate, formTvShow);
            return RedirectToAction("Details", new { id = tvShowToUpdate.Id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            TvShow tvShowToDelete = dbTvShowRepository.GetById(id, false, false, false);
            if (tvShowToDelete == null)
            {
                return NotFound();
            }
            dbTvShowRepository.Delete(tvShowToDelete);
            return RedirectToAction("Index");
        }
    }
}

using csharp_boolflix.Data.FormModels;
using csharp_boolflix.Models;
using csharp_boolflix.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    [Authorize]
    public class SeasonController : Controller
    {
        DbTvShowRepository dbTvShowRepository;
        DbSeasonRepository dbSeasonRepository;
        public SeasonController(DbTvShowRepository _dbTvShowRepository, DbSeasonRepository _dbSeasonRepository)
        {
            dbTvShowRepository = _dbTvShowRepository;
            dbSeasonRepository = _dbSeasonRepository;
        }
        public IActionResult Create(int id)
        {
            FormSeason formSeason = new FormSeason();
            formSeason.TvShow = dbTvShowRepository.GetById(id, false, false, false);
            return View(formSeason);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int id, FormSeason formSeason)
        {
            if (!ModelState.IsValid)
            {
                formSeason.TvShow = dbTvShowRepository.GetById(id, false, false, false);
                return View(formSeason);
            }
            dbSeasonRepository.Create(id, formSeason);
            return Redirect($"https://localhost:7015/TvShow/Details/{id}");
        }
        [Route("/Season/Update/{tvShowId}/{id}")]
        public IActionResult Update(int tvShowId, int id)
        {
            FormSeason formSeason = new FormSeason();
            formSeason.TvShow = dbTvShowRepository.GetById(tvShowId, false, false, false);
            formSeason.Season = dbSeasonRepository.GetById(tvShowId, id, true, true);
            if (formSeason.Season == null)
            {
                return NotFound();
            }
            return View(formSeason);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Season/Update/{tvShowId}/{id}")]
        public IActionResult Update(int tvShowId, int id, FormSeason formSeason)
        {
            Season seasonToUpdate = dbSeasonRepository.GetById(tvShowId, id, true, true);
            if (seasonToUpdate == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(formSeason);
            }
            dbSeasonRepository.Update(seasonToUpdate, formSeason);
            return Redirect($"https://localhost:7015/TvShow/Details/{tvShowId}");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Season/Delete/{tvShowId}/{id}")]
        public IActionResult Delete(int tvShowId, int id)
        {
            Season seasonToDelete = dbSeasonRepository.GetById(tvShowId, id, false, false);
            if (seasonToDelete == null)
            {
                return NotFound();
            }
            dbSeasonRepository.Delete(seasonToDelete);
            return Redirect($"https://localhost:7015/TvShow/Details/{tvShowId}");
        }
    }
}

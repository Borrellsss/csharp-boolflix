using csharp_boolflix.Data.FormModels;
using csharp_boolflix.Models;
using csharp_boolflix.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    [Authorize]
    public class EpisodeController : Controller
    {
        DbTvShowRepository dbTvShowRepository;
        DbSeasonRepository dbSeasonRepository;
        DbEpisodeRepository dbEpisodeRepository;
        public EpisodeController(DbTvShowRepository _dbTvShowRepository, DbSeasonRepository _dbSeasonRepository, DbEpisodeRepository _dbEpisodeRepository)
        {
            dbTvShowRepository = _dbTvShowRepository;
            dbSeasonRepository = _dbSeasonRepository;
            dbEpisodeRepository = _dbEpisodeRepository;
        }
        [Route("/Episode/Index/{tvShowId}/{seasonId}")]
        public IActionResult Index(int tvShowId, int seasonId)
        {
            Season season = dbSeasonRepository.GetById(tvShowId, seasonId, true, true);
            return View(season);
        }
        [Route("/Episode/Create/{tvShowId}/{seasonId}")]
        public IActionResult Create(int tvShowId, int seasonId)
        {
            FormEpisode formEpisode = new FormEpisode();
            formEpisode.Season = dbSeasonRepository.GetById(tvShowId, seasonId, true, false);
            return View(formEpisode);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Episode/Create/{tvShowId}/{seasonId}")]
        public IActionResult Create(int tvShowId, int seasonId, FormEpisode formEpisode)
        {
            if (!ModelState.IsValid)
            {
                formEpisode.Season = dbSeasonRepository.GetById(tvShowId, seasonId, true, false);
                return View(formEpisode);
            }
            dbEpisodeRepository.Create(seasonId, formEpisode);
            return Redirect($"https://localhost:7015/Episode/Index/{tvShowId}/{seasonId}");
        }
        [Route("/Episode/Update/{tvShowId}/{seasonId}/{episodeId}")]
        public IActionResult Update(int tvShowId, int seasonId, int episodeId)
        {
            FormEpisode formEpisode = new FormEpisode();
            formEpisode.Season = dbSeasonRepository.GetById(tvShowId, seasonId, true, false);
            formEpisode.Episode = dbEpisodeRepository.GetById(episodeId, false);
            if (formEpisode.Episode == null)
            {
                return NotFound();
            }
            return View(formEpisode);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Episode/Update/{tvShowId}/{seasonId}/{episodeId}")]
        public IActionResult Update(int tvShowId, int seasonId, int episodeId, FormEpisode formEpisode)
        {
            Episode episodeToUpdate = dbEpisodeRepository.GetById(episodeId, false);
            if (episodeToUpdate == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                formEpisode.Season = dbSeasonRepository.GetById(tvShowId, seasonId, true, false);
                formEpisode.Episode = dbEpisodeRepository.GetById(episodeId, false);
                return View(formEpisode);
            }
            dbEpisodeRepository.Update(episodeToUpdate, formEpisode);
            return Redirect($"https://localhost:7015/Episode/Index/{tvShowId}/{seasonId}");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Episode/Delete/{tvShowId}/{seasonId}/{episodeId}")]
        public IActionResult Delete(int tvShowId, int seasonId, int episodeId)
        {
            Episode episodeToDelete = dbEpisodeRepository.GetById(episodeId, false);
            if (episodeToDelete == null)
            {
                return NotFound();
            }
            dbEpisodeRepository.Delete(episodeToDelete);
            return Redirect($"https://localhost:7015/Episode/Index/{tvShowId}/{seasonId}");
        }
    }
}

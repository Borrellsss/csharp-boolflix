using csharp_boolflix.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    public class SeasonController : Controller
    {
        DbTvShowRepository dbTvShowRepository;
        DbSerieRepository dbSerieRepository;
        public SeasonController(DbTvShowRepository _dbTvShowRepository, DbSerieRepository _dbSerieRepository)
        {
            dbTvShowRepository = _dbTvShowRepository;
            dbSerieRepository = _dbSerieRepository;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Create(int id)
        {

            return View();
        }
    }
}

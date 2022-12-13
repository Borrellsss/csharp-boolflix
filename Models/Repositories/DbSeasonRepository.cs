using csharp_boolflix.Data.FormModels;
using csharp_boolflix.Data;
using Microsoft.EntityFrameworkCore;

namespace csharp_boolflix.Models.Repositories
{
    public class DbSeasonRepository
    {
        private BoolflixDbContext db;
        public DbSeasonRepository(BoolflixDbContext _db)
        {
            db = _db;
        }
        public List<Season> GetAll(int tvShowId, bool tvShow, bool episodes)
        {
            if (tvShow && episodes)
            {
                return db.Seasons.Include("TvShow").Include("Episodes").Where(s => s.TvShowId == tvShowId).ToList<Season>();
            }
            else if (tvShow)
            {
                return db.Seasons.Include("TvShow").Where(s => s.TvShowId == tvShowId).ToList<Season>();
            }
            else if (episodes)
            {
                return db.Seasons.Include("Episodes").Where(s => s.TvShowId == tvShowId).ToList<Season>();
            }
            return db.Seasons.Where(s => s.TvShowId == tvShowId).ToList<Season>();
        }
        public Season GetById(int tvShowId, int id, bool tvShow, bool episodes)
        {
            if (tvShow && episodes)
            {
                return db.Seasons.Include("TvShow").Include("Episodes").Where(s => s.TvShowId == tvShowId).Where(s => s.Id == id).First();
            }
            else if (tvShow)
            {
                return db.Seasons.Include("TvShow").Where(s => s.TvShowId == tvShowId).Where(s => s.Id == id).First();
            }
            else if (episodes)
            {
                return db.Seasons.Include("Episodes").Where(s => s.TvShowId == tvShowId).Where(s => s.Id == id).First();
            }
            return db.Seasons.Where(s => s.TvShowId == tvShowId).Where(s => s.Id == id).First();
        }
        public void Create(int tvShowId, FormSeason formSeason)
        {
            formSeason.Season.TvShowId = tvShowId;
            db.Add(formSeason.Season);
            db.SaveChanges();
        }
        public void Update(Season seasonToUpdate, FormSeason formSeason)
        {
            seasonToUpdate.Number = formSeason.Season.Number;
            seasonToUpdate.Title = formSeason.Season.Title;
            db.SaveChanges();
        }
        public void Delete(Season seasonToDelete)
        {
            db.Seasons.Remove(seasonToDelete);
            db.SaveChanges();
        }
    }
}
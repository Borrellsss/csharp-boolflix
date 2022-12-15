using csharp_boolflix.Data.FormModels;
using csharp_boolflix.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace csharp_boolflix.Models.Repositories
{
    public class DbEpisodeRepository
    {
        private BoolflixDbContext db;
        public DbEpisodeRepository(BoolflixDbContext _db)
        {
            db = _db;
        }
        public List<Episode> GetAll(int seasonId, bool season)
        {
            if (season)
            {
                return db.Episodes.Include("Season").Where(e => e.SeasonId == seasonId).ToList<Episode>();
            }
            return db.Episodes.Where(e => e.SeasonId == seasonId).ToList<Episode>();
        }
        public Episode GetById(int id, bool season)
        {
            if (season)
            {
                return db.Episodes.Include("Season").Where(e => e.Id == id).First();
            }
            return db.Episodes.Where(e => e.Id == id).First();
        }
        public void Create(int seasonId, FormEpisode formEpisode)
        {
            formEpisode.Episode.SeasonId = seasonId;
            db.Add(formEpisode.Episode);
            db.SaveChanges();
        }
        public void Update(Episode episodeToUpdate, FormEpisode formEpisode)
        {
            episodeToUpdate.Title = formEpisode.Episode.Title;
            episodeToUpdate.Description = formEpisode.Episode.Description;
            episodeToUpdate.Duration = formEpisode.Episode.Duration;
            db.SaveChanges();
        }
        public void Delete(Episode episodeToDelete)
        {
            db.Episodes.Remove(episodeToDelete);
            db.SaveChanges();
        }
    }
}

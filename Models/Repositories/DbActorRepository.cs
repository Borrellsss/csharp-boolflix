using csharp_boolflix.Data;
using Microsoft.EntityFrameworkCore;

namespace csharp_boolflix.Models.Repositories
{
    public class DbActorRepository
    {
        private BoolflixDbContext db;
        public DbActorRepository(BoolflixDbContext _db)
        {
            db = _db;
        }
        public List<Actor> GetAll()
        {
            return db.Actors.ToList<Actor>();
        }
        public Actor GetById(int id, bool movies, bool tvShows)
        {
            if (movies && tvShows)
            {
                return db.Actors.Include("Movies").Include("TvShows").Where(a => a.Id == id).First();
            }
            else if (movies)
            {
                return db.Actors.Include("Movies").Where(a => a.Id == id).First();
            }
            else if(tvShows)
            {
                return db.Actors.Include("TvShows").Where(a => a.Id == id).First();
            }

            return db.Actors.Where(a => a.Id == id).First();
        }
    }
}

using csharp_boolflix.Data;
using Microsoft.EntityFrameworkCore;

namespace csharp_boolflix.Models.Repositories
{
    public class DbCategoryRepository
    {
        private BoolflixDbContext db;
        public DbCategoryRepository(BoolflixDbContext _db)
        {
            db = _db;
        }
        public List<Category> GetAll()
        {
            return db.Categories.ToList<Category>();
        }
        public Category GetById(int id, bool movies, bool tvShows)
        {
            if (movies && tvShows)
            {
                return db.Categories.Include("Movies").Include("TvShows").Where(c => c.Id == id).First();
            }
            else if (movies)
            {
                return db.Categories.Include("Movies").Where(c => c.Id == id).First();
            }
            else if (tvShows)
            {
                return db.Categories.Include("TvShows").Where(c => c.Id == id).First();
            }

            return db.Categories.Where(c => c.Id == id).First();
        }
    }
}

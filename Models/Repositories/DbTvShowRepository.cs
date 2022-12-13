using csharp_boolflix.Data.FormModels;
using csharp_boolflix.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace csharp_boolflix.Models.Repositories
{
    public class DbTvShowRepository
    {
        private BoolflixDbContext db;
        public DbTvShowRepository(BoolflixDbContext _db)
        {
            db = _db;
        }
        public List<TvShow> GetAll(bool categories, bool actors)
        {
            if (categories && actors)
            {
                return db.TvShows.Include("Categories").Include("Actors").ToList<TvShow>();
            }
            else if (categories)
            {
                return db.TvShows.Include("Categories").ToList<TvShow>();
            }
            else if (actors)
            {
                return db.TvShows.Include("Actors").ToList<TvShow>();
            }

            return db.TvShows.ToList<TvShow>();
        }
        public TvShow GetLast(bool categories, bool actors)
        {
            if (categories && actors)
            {
                return db.TvShows.Include("Categories").Include("Actors").OrderBy(t => t.Id).Last();
            }
            else if (categories)
            {
                return db.TvShows.Include("Categories").OrderBy(t => t.Id).Last();
            }
            else if (actors)
            {
                return db.TvShows.Include("Actors").OrderBy(t => t.Id).Last();
            }
            return db.TvShows.OrderBy(t => t.Id).Last();
        }
        public TvShow GetById(int id, bool categories, bool actors, bool seasons)
        {
            if (categories && actors)
            {
                return db.TvShows.Include("Categories").Include("Actors").Include("Seasons").Where(t => t.Id == id).First();
            }
            else if (categories)
            {
                return db.TvShows.Include("Categories").Include("Seasons").Where(t => t.Id == id).First();
            }
            else if (actors)
            {
                return db.TvShows.Include("Actors").Include("Seasons").Where(t => t.Id == id).First();
            }
            return db.TvShows.Include("Seasons").Where(t => t.Id == id).First();
        }
        public void Create(FormTvShow formTvShow)
        {
            formTvShow.TvShow.Categories = new List<Category>();
            formTvShow.TvShow.Actors = new List<Actor>();
            if (formTvShow.SelectedCategories != null)
            {
                foreach (int categoryId in formTvShow.SelectedCategories)
                {
                    Category selectedCategory = db.Categories.Find(categoryId);
                    formTvShow.TvShow.Categories.Add(selectedCategory);
                }
            }
            if (formTvShow.SelectedActors != null)
            {
                foreach (int actorId in formTvShow.SelectedActors)
                {
                    Actor SelectedActor = db.Actors.Find(actorId);
                    formTvShow.TvShow.Actors.Add(SelectedActor);
                }
            }
            db.Add(formTvShow.TvShow);
            db.SaveChanges();
        }
        public void Update(TvShow tvShowToUpdate, FormTvShow formTvShow)
        {
            tvShowToUpdate.Title = formTvShow.TvShow.Title;
            tvShowToUpdate.Description = formTvShow.TvShow.Description;
            tvShowToUpdate.Director = formTvShow.TvShow.Director;
            tvShowToUpdate.Cover = formTvShow.TvShow.Cover;
            tvShowToUpdate.ReleaseDate = formTvShow.TvShow.ReleaseDate;
            if (tvShowToUpdate.Categories != null)
            {
                tvShowToUpdate.Categories.Clear();
            }
            else
            {
                tvShowToUpdate.Categories = new List<Category>();
            }
            if (tvShowToUpdate.Actors != null)
            {
                tvShowToUpdate.Actors.Clear();
            }
            else
            {
                tvShowToUpdate.Actors = new List<Actor>();
            }
            if (formTvShow.SelectedCategories != null)
            {
                foreach (int categoryId in formTvShow.SelectedCategories)
                {
                    Category selectedCategory = db.Categories.Find(categoryId);
                    tvShowToUpdate.Categories.Add(selectedCategory);
                }
            }
            if (formTvShow.SelectedActors != null)
            {
                foreach (int actorId in formTvShow.SelectedActors)
                {
                    Actor SelectedActor = db.Actors.Find(actorId);
                    tvShowToUpdate.Actors.Add(SelectedActor);
                }
            }
            db.SaveChanges();
        }
        public void Delete(TvShow tvShowToDelete)
        {
            db.TvShows.Remove(tvShowToDelete);
            db.SaveChanges();
        }
    }
}
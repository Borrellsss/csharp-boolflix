using csharp_boolflix.Data.FormModels;
using csharp_boolflix.Data;

namespace csharp_boolflix.Models.Repositories
{
    public class DbSerieRepository
    {
        private BoolflixDbContext db;
        public DbSerieRepository(BoolflixDbContext _db)
        {
            db = _db;
        }
        //public List<Movie> GetAll(bool categories, bool actors)
        //{
        //    if (categories && actors)
        //    {
        //        return db.Movies.Include("Categories").Include("Actors").ToList<Movie>();
        //    }
        //    else if (categories)
        //    {
        //        return db.Movies.Include("Categories").ToList<Movie>();
        //    }
        //    else if (actors)
        //    {
        //        return db.Movies.Include("Actors").ToList<Movie>();
        //    }

        //    return db.Movies.ToList<Movie>();
        //}
        //public Movie GetLast(bool categories, bool actors)
        //{
        //    if (categories && actors)
        //    {
        //        return db.Movies.Include("Categories").Include("Actors").OrderBy(m => m.Id).Last();
        //    }
        //    else if (categories)
        //    {
        //        return db.Movies.Include("Categories").OrderBy(m => m.Id).Last();
        //    }
        //    else if (actors)
        //    {
        //        return db.Movies.Include("Actors").OrderBy(m => m.Id).Last();
        //    }
        //    return db.Movies.OrderBy(m => m.Id).Last();
        //}
        //public Movie GetById(int id, bool categories, bool actors)
        //{
        //    if (categories && actors)
        //    {
        //        return db.Movies.Include("Categories").Include("Actors").Where(m => m.Id == id).First();
        //    }
        //    else if (categories)
        //    {
        //        return db.Movies.Include("Categories").Where(m => m.Id == id).First();
        //    }
        //    else if (actors)
        //    {
        //        return db.Movies.Include("Actors").Where(m => m.Id == id).First();
        //    }

        //    return db.Movies.Where(m => m.Id == id).First();
        //}
        public void Create(FormSeason formSeason)
        {
            db.Add(formSeason.Season);
            db.SaveChanges();
        }
        //public void Update(Movie movieToUpdate, FormMovie formMovie)
        //{
        //    movieToUpdate.Title = formMovie.Movie.Title;
        //    movieToUpdate.Description = formMovie.Movie.Description;
        //    movieToUpdate.Director = formMovie.Movie.Director;
        //    movieToUpdate.Cover = formMovie.Movie.Cover;
        //    movieToUpdate.ReleaseDate = formMovie.Movie.ReleaseDate;
        //    movieToUpdate.Duration = formMovie.Movie.Duration;
        //    if (movieToUpdate.Categories != null)
        //    {
        //        movieToUpdate.Categories.Clear();
        //    }
        //    else
        //    {
        //        movieToUpdate.Categories = new List<Category>();
        //    }
        //    if (movieToUpdate.Actors != null)
        //    {
        //        movieToUpdate.Actors.Clear();
        //    }
        //    else
        //    {
        //        movieToUpdate.Actors = new List<Actor>();
        //    }
        //    if (formMovie.SelectedCategories != null)
        //    {
        //        foreach (int categoryId in formMovie.SelectedCategories)
        //        {
        //            Category selectedCategory = db.Categories.Find(categoryId);
        //            movieToUpdate.Categories.Add(selectedCategory);
        //        }
        //    }
        //    if (formMovie.SelectedActors != null)
        //    {
        //        foreach (int actorId in formMovie.SelectedActors)
        //        {
        //            Actor SelectedActor = db.Actors.Find(actorId);
        //            movieToUpdate.Actors.Add(SelectedActor);
        //        }
        //    }
        //    db.SaveChanges();
        //}
        //public void Delete(Movie movieToDelete)
        //{
        //    db.Movies.Remove(movieToDelete);
        //    db.SaveChanges();
        //}
    }
}

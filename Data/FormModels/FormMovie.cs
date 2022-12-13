using csharp_boolflix.Models;

namespace csharp_boolflix.Data.FormModels
{
    public class FormMovie
    {
        public Movie Movie { get; set; }
        public List<Category>? Categories { get; set; }
        public List<int> SelectedCategories { get; set; }
        public List<Actor>? Actors { get; set; }
        public List<int> SelectedActors { get; set; }
    }
}

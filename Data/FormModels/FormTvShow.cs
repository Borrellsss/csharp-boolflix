using csharp_boolflix.Models;

namespace csharp_boolflix.Data.FormModels
{
    public class FormTvShow
    {
        public TvShow TvShow { get; set; }
        public List<Category>? Categories { get; set; }
        public List<int> SelectedCategories { get; set; }
        public List<Actor>? Actors { get; set; }
        public List<int> SelectedActors { get; set; }
    }
}

namespace csharp_boolflix.Models
{
    public abstract class Content
    {
        protected Content()
        {

        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Director { get; set; }
        public string? Cover { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Actor>? Actors { get; set; }
    }
}
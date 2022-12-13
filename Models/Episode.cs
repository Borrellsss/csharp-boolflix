namespace csharp_boolflix.Models
{
    public class Episode
    {
        public Episode()
        {

        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int SeasonId { get; set; }
        public Season? Season { get; set; }
    }
}
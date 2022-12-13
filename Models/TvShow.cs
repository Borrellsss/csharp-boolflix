namespace csharp_boolflix.Models
{
    public class TvShow : Content
    {
        public TvShow()
        {

        }
        public List<Season>? Seasons { get; set; }
    }
}
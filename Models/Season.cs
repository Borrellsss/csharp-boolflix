namespace csharp_boolflix.Models
{
    public class Season
    {
        public Season()
        {

        }
        public int Id { get; set; }
        public int Number { get; set; }
        public int TvShowId { get; set; }
        public TvShow? TvShow { get; set; }
        public List<Episode>? Episodes { get; set; }
    }
}

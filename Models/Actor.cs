namespace csharp_boolflix.Models
{
    public class Actor
    {
        public Actor()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Content>? Contents { get; set; }
    }
}

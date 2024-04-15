namespace Movie_Point.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public List<Movie> Movies { get; set; }
    }
}

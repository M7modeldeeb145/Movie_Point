namespace Movie_Point.Models
{
    public class Cinema
    {
        public int CinemaId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } 
        public string? Cinemaloga { get; set; }
        public string? Address { get; set; }
        public List<Movie> Movies { get; set; }
    }
}

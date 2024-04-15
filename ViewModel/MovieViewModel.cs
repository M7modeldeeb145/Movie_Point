using Movie_Point.Models;
using System.ComponentModel.DataAnnotations;

namespace Movie_Point.ViewModel
{
	public class MovieViewModel
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } = null!;
        public string? Description { get; set; }
		public double Price { get; set; }
		//[RegularExpression]
		public string ImgUrl { get; set; } = null!;
		public string? TrailerUrl { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public MovieStatus MovieStatus { get; set; }
		public int CinemaId { get; set; }
		public int CategoryId { get; set; }
	}
}

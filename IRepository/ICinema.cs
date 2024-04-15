using Movie_Point.Models;

namespace Movie_Point.IRepository
{
	public interface ICinema
	{
		void Delete(int id);
		void Create (Cinema cinema);
		void Update (Cinema cinema);
		List<Cinema> GetAll();
		Cinema Get(int id);
		List<Movie> GetMoviesWithCinemaId(int id);
		
	}
}

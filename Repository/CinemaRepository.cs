using Microsoft.EntityFrameworkCore;
using Movie_Point.Data;
using Movie_Point.IRepository;
using Movie_Point.Models;

namespace Movie_Point.Repository
{
	public class CinemaRepository : ICinema
	{
		ApplicationDbContext context; //= new ApplicationDbContext();
		public CinemaRepository(ApplicationDbContext context)
		{
			this.context = context;
		}
		public void Create(Cinema cinema)
		{
			context.cinemas.Add(new Cinema { CinemaId = cinema.CinemaId,Name=cinema.Name,Description=cinema.Description,Address=cinema.Address,Cinemaloga=cinema.Cinemaloga});
			context.SaveChanges();
		}
		public void Delete(int id)
		{
			var cinema = context.cinemas.Find(id);
			if (cinema != null)
			{
				context.cinemas.Remove(cinema);
				context.SaveChanges();
			}
		}
		public Cinema Get(int id)
		{
			return context.cinemas.Find(id);
		}
		public List<Cinema> GetAll()
		{
			return context.cinemas.ToList();
		}

        public List<Movie> GetMoviesWithCinemaId(int id)
        {
            return context.Movies.Include(e=>e.Cinema).Include(e=>e.Category).Where(e=>e.CinemaId == id).ToList();
        }

        public void Update(Cinema cinema)
		{
			var cin = context.cinemas.Find(cinema.CinemaId);
			if (cin != null)
			{
				cin.Name = cinema.Name;
				cin.Description = cinema.Description;
				cin.Address = cinema.Address;
				cin.Cinemaloga= cinema.Cinemaloga;
				context.SaveChanges();
			}
		}
	}
}

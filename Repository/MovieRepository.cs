using Microsoft.EntityFrameworkCore;
using Movie_Point.Data;
using Movie_Point.IRepository;
using Movie_Point.Models;
using Movie_Point.ViewModel;

namespace Movie_Point.Repository
{
    public class MovieRepository : IMovie
    {
        ApplicationDbContext context;//= new ApplicationDbContext();
        public MovieRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var movie=context.Movies.Find(id);
            if(movie != null)
            {
                context.Movies.Remove(movie);
                context.SaveChanges();
            }

        }
        public Movie Get(int id)
        {
            return context.Movies.Find(id);
        }
        public Movie GetMovieWithDept(int id)
        {
            return context.Movies.Include(e=>e.Actors).Include(e=>e.Category).Include(e=>e.Cinema).First(e=>e.Id == id);
        }

        public List<Category> GetCategories()
		{
			return context.categories.ToList();
		}

		public List<Cinema> GetCinemas()
		{
			return context.cinemas.ToList();
		}

        public List<Movie> GetMoviesWithActors()
        {
            return context.Movies.Include(e=>e.Actors).ToList();
        }

        public List<Movie> ReadAll()
        {
            return context.Movies.ToList();
        }
        public List<Movie> ReadAllWithCinema_Category()
        {
           return context.Movies.Include(e => e.Cinema).Include(e => e.Category).ToList();
        }
        public void Update(Movie movie)
        {
            var mov =context.Movies.Find(movie.Id);
            if(mov != null)
            {
                mov.Name = movie.Name;
                mov.Description = movie.Description;
                mov.Price = movie.Price;
                mov.MovieStatus = movie.MovieStatus;
                mov.StartDate = movie.StartDate;
                mov.EndDate = movie.EndDate;
                mov.CategoryId = movie.CategoryId;
                mov.CinemaId = movie.CinemaId;
                mov.ImgUrl = movie.ImgUrl;
                mov.TrailerUrl = movie.TrailerUrl;
                
                context.SaveChanges();
            }
        }
        public void Update(MovieViewModel movie)
        {
            var mov =context.Movies.Find(movie.Id);
            if(mov != null)
            {
                mov.Name = movie.Name;
                mov.Description = movie.Description;
                mov.Price = movie.Price;
                mov.MovieStatus = movie.MovieStatus;
                mov.StartDate = movie.StartDate;
                mov.EndDate = movie.EndDate;
                mov.CategoryId = movie.CategoryId;
                mov.CinemaId = movie.CinemaId;
                mov.ImgUrl = movie.ImgUrl;
                mov.TrailerUrl = movie.TrailerUrl;
                
                context.SaveChanges();
            }
        }

        public List<Movie> Search(string Name)
        {
            return context.Movies.Include(e=>e.Category).Include(e=>e.Cinema).Where(e=>e.Name.Contains(Name)).ToList();
        }
    }
}

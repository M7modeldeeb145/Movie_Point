using Movie_Point.Models;
using Movie_Point.ViewModel;

namespace Movie_Point.IRepository
{
    public interface IMovie
    {
        List<Movie> Search(string Name);
        void Delete (int id);
        void Update (Movie movie);
        void Update (MovieViewModel movie);
        List<Movie> ReadAll();
        List<Movie> ReadAllWithCinema_Category();
        Movie Get (int id);
        Movie GetMovieWithDept(int id);
        void Create (Movie movie);
        List<Category> GetCategories ();
        List<Cinema> GetCinemas ();
        List<Movie> GetMoviesWithActors ();

    }
}

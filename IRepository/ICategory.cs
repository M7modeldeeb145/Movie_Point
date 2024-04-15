using Movie_Point.Data;
using Movie_Point.Models;

namespace Movie_Point.IRepository
{
    public interface ICategory
    {
        void Delete(int id);
        List<Category> GetAll();
        void Create(Category category);
        void Update(Category category);
        Category Get (int id);
        void Details(int id);
        List<Movie> GetMoviesByCatId(int id);
    }
}

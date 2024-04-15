using Microsoft.EntityFrameworkCore;
using Movie_Point.Data;
using Movie_Point.IRepository;
using Movie_Point.Models;

namespace Movie_Point.Repository
{
    public class CategoryRepository : ICategory
    {
        ApplicationDbContext Context; //= new ApplicationDbContext();
        public CategoryRepository(ApplicationDbContext Context)
        {
            this.Context = Context;
        }
        public void Create(Category category)
        {
            Context.categories.Add(category);
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            var cat =Context.categories.Find(id);
            if (cat != null)
            {
                Context.categories.Remove(cat);
                Context.SaveChanges();
            }
        }

        public void Details(int id)
        {
            var listofmovies =Context.categories.Where(e => e.CategoryId == id).ToList();
        }

        public Category Get(int id)
        {
            return Context.categories.Find(id);
        }
        public List<Category> GetAll()
        {
            return Context.categories.ToList();
        }

        public List<Movie> GetMoviesByCatId(int id)
        {
            var movies = Context.Movies.Include(e => e.Category).Include(e=>e.Cinema).Where(e => e.CategoryId == id).ToList();
            return movies;
        }
        public void Update(Category category)
        {
            var cat = Context.categories.Find(category.CategoryId);
            if (cat != null)
            {
                cat.Name = category.Name;
                cat.CategoryId = category.CategoryId;
                Context.SaveChanges();
            }
        }

    }
}

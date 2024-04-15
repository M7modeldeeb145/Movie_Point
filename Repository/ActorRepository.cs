using Movie_Point.Data;
using Movie_Point.IRepository;
using Movie_Point.Models;

namespace Movie_Point.Repository
{
    public class ActorRepository : IActor
    {
        ApplicationDbContext context;
        public ActorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Actor actor)
        {
            context.Actors.Add(actor);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var actor = context.Actors.Find(id);
            if (actor != null)
            {
                context.Actors.Remove(actor);
                context.SaveChanges();
            }
        }

        public Actor GetById(int id)
        {
            return context.Actors.Find(id);
        }

        public List<Actor> ReadAll()
        {
            return context.Actors.ToList();
        }

        public void Update(Actor actor)
        {
            var Edit = context.Actors.Find(actor.Id);
            if (Edit != null)
            {
                Edit.FirstName = actor.FirstName;
                Edit.LastName = actor.LastName;
                Edit.ProfilePicture = actor.ProfilePicture;
                Edit.Bio = actor.Bio;
                Edit.News = actor.News;
                context.SaveChanges();
            }
        }
    }
}

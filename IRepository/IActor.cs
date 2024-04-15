using Movie_Point.Models;

namespace Movie_Point.IRepository
{
    public interface IActor
    {
        List<Actor> ReadAll();
        void Update(Actor actor);
        void Create (Actor actor);
        void Delete (int id);
        Actor GetById (int id);

    }
}

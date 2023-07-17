using Domain.Model.DataBase;
using Domain.Models.Request;

namespace Domain.Repository.Interfaces
{
    public interface IActorRepository
    {
        IList<Actor> Get();
        Actor Get(int id);
        void Create(ActorRequest actor);
        void Update(int id, ActorRequest actor);
        void Delete(int id);
        List<Actor> MoviesActors(int id);
    }
}

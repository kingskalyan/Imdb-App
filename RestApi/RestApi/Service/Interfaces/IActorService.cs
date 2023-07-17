using Domain.Models.Request;
using Domain.Models.Response;

namespace Service.Interfaces
{
    public interface IActorService
    {
        public IList<ActorResponse> Get();
        public ActorResponse Get(int id);
        public void Create(ActorRequest actor);
        public void Update(int id, ActorRequest actor);
        public void Delete(int id);
        List<ActorResponse> MoviesActors(int movieId);
    }
}

using Domain.Models.Request;
using Domain.Models.Response;
using Domain.Repository.Interfaces;
using Service.Interfaces;

namespace Service
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }
        public void Create(ActorRequest actor)
        {
            _actorRepository.Create(actor);
        }

        public void Delete(int id)
        {
            _actorRepository.Delete(id);
        }

        public IList<ActorResponse> Get()
        {
            var actorResponse = new List<ActorResponse>();
            
            actorResponse = _actorRepository.Get().Select(a=> new ActorResponse() { Id = a.Id , Bio = a.Bio , DateOfBirth = a.DateOfBirth, Name = a.Name , Gender = a.Gender}).ToList();
            if(actorResponse == null)
            {
                return null;
            }
            return actorResponse;
        }

        public ActorResponse Get(int id)
        {
            var response = new ActorResponse();
            var actor = _actorRepository.Get(id);
            if(actor == null)
            {
                return null;
            }

            response.Id = id;
            response.Name = actor.Name;
            response.Bio = actor.Bio;
            response.DateOfBirth = actor.DateOfBirth;
            response.Gender = actor.Gender;

            return response;
        }

        public List<ActorResponse> MoviesActors(int movieId)
        {
            var actorResponse = new List<ActorResponse>();
            var actors = _actorRepository.MoviesActors(movieId);
            if(actors == null)
            {
                return null;
            }
            foreach (var actor in actors)
            {
                var temp = new ActorResponse() { Id = actor.Id, Name = actor.Name, Bio = actor.Bio, DateOfBirth = actor.DateOfBirth, Gender = actor.Gender };
                actorResponse.Add(temp);
            }
            return actorResponse;
        }

        public void Update(int id, ActorRequest actor)
        {
            _actorRepository.Update(id, actor);
        }
    }


}

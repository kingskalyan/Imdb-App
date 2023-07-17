using Domain.Model.DataBase;
using Domain.Models.Request;
using Domain.Models.Response;
using Domain.Repository.Interfaces;
using Moq;

namespace RestApi.Tests.Mocks
{

    public class ActorMock
    {
        public static readonly Mock<IActorRepository> ActorRepoMock = new Mock<IActorRepository>();
        public static readonly List<Actor> ListOfActors = new List<Actor>()
        {
            new Actor()
            {
                Id = 1,
                Name = "Robert Brown Junior",
                Bio = "Robert Brown Junior is a renowned American actor known for his iconic portrayal of Tony Stark, also known as Iron Man, in the Marvel Cinematic Universe.",
                DateOfBirth = new DateTime(1965,04,04),
                Gender = "Male"
            },
            new Actor()
            {
                Id = 2,
                Name = "Will Smith",
                Bio = "Steve Rogers, a scrawny but patriotic young man who is given super-soldier serum and becomes Captain America",
                DateOfBirth = new DateTime(1976,06,13),
                Gender = "Male"
            },
            new Actor()
            {
                Id = 3,
                Name = "Chris Hemsworth",
                Bio = "Thor, the Asgardian god of thunder",
                DateOfBirth = new DateTime(1983,8,13),
                Gender = "Male"
            }
        };

        private static readonly Dictionary<int, int> _moviesActor = new Dictionary<int, int>()
        {
            {1,2}
        };

        public static void GetActors()
        {
            ActorRepoMock.Setup(a => a.Get()).Returns(ListOfActors);

            ActorRepoMock.Setup(a => a.Get(It.IsAny<int>())).Returns((int id) => ListOfActors.FirstOrDefault(actor => actor.Id == id));

            ActorRepoMock.Setup(a => a.Delete(It.IsAny<int>())).Callback((int id) =>
            {
                var result = ListOfActors.FirstOrDefault(actor => actor.Id == id).Id;
                ListOfActors.RemoveAt(id - 1);
            });

            ActorRepoMock.Setup(a => a.Update(It.IsAny<int>(), It.IsAny<ActorRequest>())).Callback((int id, ActorRequest request) =>
            {
                var actor = new ActorResponse() { Id = request.Id, Name = request.Name, Bio = request.Bio, DateOfBirth = request.DateOfBirth, Gender = request.Gender };
                var result = ListOfActors.FindIndex(ac => ac.Id == id);
                ListOfActors[result].Name = actor.Name;
                ListOfActors[result].DateOfBirth = actor.DateOfBirth;
                ListOfActors[result].Gender = actor.Gender;
                ListOfActors[result].Bio = actor.Bio;

            });

            ActorRepoMock.Setup(a => a.Create(It.IsAny<ActorRequest>())).Callback((ActorRequest actorRequest) =>
            {
                var actor = new Actor()
                {
                    Id = ListOfActors.Count() + 1,
                    Name = actorRequest.Name,
                    Bio = actorRequest.Bio,
                    DateOfBirth = actorRequest.DateOfBirth,
                    Gender = actorRequest.Gender
                };
                ListOfActors.Add(actor);
            });

            ActorRepoMock.Setup(a => a.MoviesActors(It.IsAny<int>())).Returns((int movieId) =>
            {
                var actors = new List<Actor>();
                foreach (var item in _moviesActor)
                {
                    if (item.Key == movieId)
                    {
                        var actor = ListOfActors.Find(a => a.Id == item.Value);
                        actors.Add(actor);
                    }
                }
                return actors;
            });
        }
    }
}

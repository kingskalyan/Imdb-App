using Domain.Model.DataBase;
using Domain.Models.Request;
using Domain.Models.Response;
using Domain.Repository.Interfaces;
using Moq;

namespace RestApi.Tests.Mocks
{
    public class ProducerMock
    {
        public static readonly Mock<IProducerRepository> ProducerRepoMock = new Mock<IProducerRepository>();
        private static readonly List<Producer> _listOfProducers = new List<Producer>()
        {
            new Producer()
            {
                Id = 1,
                Name = "S.S. Rajamouli",
                Bio = "S.S. Rajamouli is an Indian film director and screenwriter who primarily works in Telugu cinema and is known for his action, fantasy, and epic genre films. He is the highest grossing Indian director of all time and the highest-paid director in India. ",
                DateOfBirth = new DateTime(1973,10,20),
                Gender = "Male"
            }
        };


        public static void GetProducers()
        {
            ProducerRepoMock.Setup(a => a.Get()).Returns(_listOfProducers);
            ProducerRepoMock.Setup(p => p.Get(It.IsAny<int>())).Returns((int id) => _listOfProducers.FirstOrDefault(a => a.Id == id));

            ProducerRepoMock.Setup(a => a.Delete(It.IsAny<int>())).Callback((int id) =>
            {
                var result = _listOfProducers.FindIndex(producer => producer.Id == id);
                _listOfProducers.RemoveAt(result);
            });

            ProducerRepoMock.Setup(a => a.Update(It.IsAny<int>(), It.IsAny<ProducerRequest>())).Callback((int id, ProducerRequest request) =>
            {
                var producer = new Producer() { Id = request.Id, Name = request.Name, Bio = request.Bio, DateOfBirth = request.DateOfBirth, Gender = request.Gender };
                var result = _listOfProducers.FindIndex(ac => ac.Id == id);
                _listOfProducers[result].Name = producer.Name;
                _listOfProducers[result].DateOfBirth = producer.DateOfBirth;
                _listOfProducers[result].Gender = producer.Gender;
                _listOfProducers[result].Bio = producer.Bio;

            });

            ProducerRepoMock.Setup(a => a.Create(It.IsAny<ProducerRequest>())).Callback((ProducerRequest actorRequest) =>
            {
                var producer = new Producer()
                {
                    Id = _listOfProducers.Count() + 1,
                    Name = actorRequest.Name,
                    Bio = actorRequest.Bio,
                    DateOfBirth = actorRequest.DateOfBirth,
                    Gender = actorRequest.Gender
                };
                _listOfProducers.Add(producer);
            });
        }
    }
}

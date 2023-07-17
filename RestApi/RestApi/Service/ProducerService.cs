using Domain.Models.Request;
using Domain.Models.Response;
using Domain.Repository;
using Domain.Repository.Interfaces;
using Service.Interfaces;

namespace Service
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public void Create(ProducerRequest producer)
        {
            _producerRepository.Create(producer);
        }

        public void Delete(int id)
        {
            _producerRepository.Delete(id);
        }

        public IList<ProducerResponse> Get()
        {
            var producerResponse = new List<ProducerResponse>();
            producerResponse = _producerRepository.Get().Select(p => new ProducerResponse() { Id = p.Id, Bio = p.Bio, DateOfBirth = p.DateOfBirth, Name = p.Name, Gender = p.Gender }).ToList();
            return producerResponse;
        }

        public ProducerResponse Get(int id)
        {
            var response = new ProducerResponse();
            var producer = _producerRepository.Get(id);
            if(producer == null)
            {
                return null;
            }

            response.Id = id;
            response.Name = producer.Name;
            response.Bio = producer.Bio;
            response.DateOfBirth = producer.DateOfBirth;
            response.Gender = producer.Gender;

            return response;
        }

        public void Update(int id, ProducerRequest producer)
        {
            _producerRepository.Update(id, producer);
        }
    }


}

using Domain.Models.Request;
using Domain.Models.Response;

namespace Service.Interfaces
{
    public interface IProducerService
    {
        public IList<ProducerResponse> Get();
        public ProducerResponse Get(int id);
        public void Create(ProducerRequest producer);
        public void Update(int id, ProducerRequest producer);
        public void Delete(int id);
    }
}

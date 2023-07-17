using Domain.Model.DataBase;
using Domain.Models.Request;

namespace Domain.Repository.Interfaces
{
    public interface IProducerRepository
    {
        IList<Producer> Get();
        Producer Get(int id);
        void Create(ProducerRequest producer);
        void Update(int id, ProducerRequest producer);
        void Delete(int id);
    }
}

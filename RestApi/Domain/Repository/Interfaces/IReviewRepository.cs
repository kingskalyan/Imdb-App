using Domain.Model.DataBase;
using Domain.Models.Request;

namespace Domain.Repository.Interfaces
{
    public interface IReviewRepository
    {
        IList<Review> Get(int movieId);
        Review Get(int id, int movieId);
        void Create(ReviewRequest review);
        void Update(int id, ReviewRequest review);
        void Delete(int id);
    }
}

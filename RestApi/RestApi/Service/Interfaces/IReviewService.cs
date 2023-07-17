using Domain.Models.Request;
using Domain.Models.Response;

namespace Service.Interfaces
{
    public interface IReviewService
    {
        public IList<ReviewResponse> Get(int movieId);
        public ReviewResponse Get(int id, int movieId);
        public void Create(ReviewRequest review);
        public void Update(int id, ReviewRequest review);
        public void Delete(int id);
    }
}

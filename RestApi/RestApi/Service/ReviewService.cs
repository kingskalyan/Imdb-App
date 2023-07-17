using Domain.Models.Request;
using Domain.Models.Response;
using Domain.Repository.Interfaces;
using Service.Interfaces;

namespace Service
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public void Create(ReviewRequest review)
        {
            _reviewRepository.Create(review);
        }

        public void Delete(int id)
        {
            _reviewRepository.Delete(id);
        }

        public IList<ReviewResponse> Get(int movieId)
        {
            var reviews = _reviewRepository.Get(movieId);
            var reviewResponse = new List<ReviewResponse>();
            foreach (var item in reviews)
            {
                var review = new ReviewResponse();
                review.Id = item.Id;
                review.Message = item.Message;
                reviewResponse.Add(review);
            }
            return reviewResponse;
        }

        public ReviewResponse Get(int id, int movieId)
        {
            var review = _reviewRepository.Get(id,movieId);
            if(review == null)
            {
                return null;
            }
            return new ReviewResponse() { Id = review.Id ,Message = review.Message};
        }

        public void Update(int id, ReviewRequest review)
        {
            _reviewRepository.Update(id, review);
        }
    }


}

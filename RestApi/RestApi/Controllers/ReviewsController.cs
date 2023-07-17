using Domain.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewsService;

        public ReviewsController(IReviewService reviewsService)
        {
            _reviewsService = reviewsService;
        }
        [HttpGet("{movieId}")]
        public IActionResult Get([FromRoute]int movieId)
        {
            return Ok(_reviewsService.Get(movieId));
        }

        [HttpGet("{movieId}/id/{id}")]
        public IActionResult Get([FromRoute]int id, [FromRoute]int movieId)
        {
            var result = _reviewsService.Get(id,movieId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ReviewRequest review)
        {
            _reviewsService.Create(review);
            return Created("~/api/Review/Get", review);
        }

        [HttpDelete("id/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _reviewsService.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            _reviewsService.Delete(id);
            return Ok();
        }

        [HttpPut("id/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ReviewRequest review)
        {
            var result = _reviewsService.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            _reviewsService.Update(id, review);
            return Ok();
        }
    }
}

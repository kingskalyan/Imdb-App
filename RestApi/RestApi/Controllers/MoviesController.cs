using Domain.Models.Request;
using Firebase.Storage;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interfaces;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _moviesService;

        public MoviesController(IMovieService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_moviesService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                var result = _moviesService.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] MovieRequest movie)
        {
            try
            {
                _moviesService.Create(movie);
                return Created("~/api/Movies/", movie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var result = _moviesService.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                _moviesService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] MovieRequest movie)
        {
            try
            {
                var result = _moviesService.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                _moviesService.Update(id, movie);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile image)
        {
            if (image == null || image.Length == 0)
                return Content("file not selected");


            var task = await new FirebaseStorage("imdb-e048e.appspot.com")
                    .Child(Guid.NewGuid().ToString() + ".jpg")
                    .PutAsync(image.OpenReadStream());

            return Ok(task);
        }
    }
}

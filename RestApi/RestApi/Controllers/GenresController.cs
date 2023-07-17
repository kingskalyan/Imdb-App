using Domain.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genresService;

        public GenresController(IGenreService genresService)
        {
            _genresService = genresService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_genresService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _genresService.Get(id);
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
        public IActionResult Create([FromBody] GenreRequest genre)
        {
            try
            {
                _genresService.Create(genre);
                return Created("~/api/Genres/Get", genre);
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
                var result = _genresService.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                _genresService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] GenreRequest genre)
        {
            try
            {
                var result = _genresService.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                _genresService.Update(id, genre);
                return Ok(_genresService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

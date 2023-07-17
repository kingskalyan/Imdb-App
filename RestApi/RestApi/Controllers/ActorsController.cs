using Domain.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;



namespace RestApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorsService;

        public ActorsController(IActorService actorsService)
        {
            _actorsService = actorsService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_actorsService.Get());
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
                var result = _actorsService.Get(id);
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _actorsService.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                _actorsService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ActorRequest actor)
        {
            try
            {
                _actorsService.Create(actor);
                return Created("~/api/Actors/Get/", actor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] ActorRequest actor, [FromRoute] int id)
        {
            try
            {
                var result = _actorsService.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                _actorsService.Update(id, actor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

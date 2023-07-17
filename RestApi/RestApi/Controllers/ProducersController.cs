using Domain.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly IProducerService _producersService;

        public ProducersController(IProducerService producersService)
        {
            _producersService = producersService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_producersService.Get());
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
                var result = _producersService.Get(id);
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
                var result = _producersService.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                _producersService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProducerRequest producer)
        {
            try
            {
                _producersService.Create(producer);
                return Created("~/api/Producer/Get", producer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] ProducerRequest producer, [FromRoute] int id)
        {
            try
            {
                var result = _producersService.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                _producersService.Update(id, producer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

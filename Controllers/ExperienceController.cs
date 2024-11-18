using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Controllers
{
    [Route("API/Experience")]
    [ApiController]
    //[Authorize]
    public class ExperienceController : ControllerBase
    {
        private readonly IService<Experience> _service;

        public ExperienceController(IService<Experience> service)
        {
            _service = service;
        }

        [HttpGet("GetData")]
        public IActionResult GetData()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        [HttpPost("AddData")]
        public IActionResult AddData([FromBody] Experience experience)
        {
            _service.Add(experience);
            return Ok();
        }

        [HttpPut("EditData")]
        public IActionResult EditData([FromBody] Experience experience)
        {
            _service.Update(experience);
            return Ok();
        }

        [HttpDelete("DeleteData/{id}")]
        public IActionResult DeleteData(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }

}

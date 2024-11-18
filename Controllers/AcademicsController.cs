using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Controllers
{
    [Route("API/Academics")]
    [ApiController]
    //[Authorize]
    public class AcademicsController : ControllerBase
    {
        private readonly IService<Academics> _service;

        public AcademicsController(IService<Academics> service)
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
        public IActionResult AddData([FromBody] Academics academics)
        {
            _service.Add(academics);
            return Ok();
        }

        [HttpPut("EditData")]
        public IActionResult EditData([FromBody] Academics academics)
        {
            _service.Update(academics);
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

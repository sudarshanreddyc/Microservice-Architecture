using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Controllers
{
    [Route("API/Skills")]
    [ApiController]
    //[Authorize]
    public class SkillsController : ControllerBase
    {
        private readonly IService<Skills> _service;

        public SkillsController(IService<Skills> service)
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
        public IActionResult AddData([FromBody] Skills skills)
        {
            _service.Add(skills);
            return Ok();
        }

        [HttpPut("EditData")]
        public IActionResult EditData([FromBody] Skills skills)
        {
            _service.Update(skills);
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

using Business.Abstract;
using Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("person")]
    public class PersonController : Controller
    {
        private IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("merhaba");

        }

        [HttpGet("GetPersonList")]
        public IActionResult GetPersonList()
        {
            var result = _personService.GetAll();
            return Ok(result);

        }
        [HttpPost("CreatePerson")]
        public IActionResult CreatePerson([FromBody] CreatePersonDto request)
        {
            string sonuc = _personService.Create(request);
            return Ok(sonuc);
        }

        [HttpPut("UpdatePerson")]
        public IActionResult UpdatePerson([FromBody] UpdatePersonDto request)
        {
            _personService.Update(request);
            return Ok();
        }
        [HttpDelete("DeletePerson")]
        public IActionResult DeletePerson([FromBody] DeleteDto request)
        {
            _personService.Delete(request);
            return Ok();
        }
        
       
    }
}

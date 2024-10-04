using Business.Abstract;
using Business.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("person")]
    public class PersonController : Controller
    {
        private IPersonService  _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Ok");

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
            _personService.Create(request);
            return Ok();
        }

        [HttpPut("UpdatePerson")]
        public IActionResult UpdatePerson([FromBody] UpdatePersonDto request)
        {
            _personService.Update(request);
            return Ok();
        }
        [HttpDelete("DeletePerson")]
        public IActionResult DeletePerson(int id)
        {
            _personService.Delete(id);
            return Ok();
        }
    }
}

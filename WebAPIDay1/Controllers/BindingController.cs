using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDay1.Models;

namespace WebAPIDay1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//bind ,filter validation
    public class BindingController : ControllerBase
    {

        [HttpPost("test")]
        
        public IActionResult TestVali(Student std)
        {
            if(ModelState.IsValid)
            {
                return Ok("Done");
            }
            
            return BadRequest("Invalid Obj");
        }
        //request type Get & Delete without body
        //route placeholder case sentisve
        [HttpGet("{id}")]
        
        public IActionResult M1(int id)//primitive (QS /Route Segmate)
        {
            
            return Ok();
        }
        //Reuest POST or PUT with bosy in request
        [HttpPost]
        public IActionResult M2(Department dept,string? name) {
            return Ok();
        }

        //binding can change source
        // [HttpGet("{id}/{Name}/{ManagerName}")]//api/binding/1/sd/ahmed [FromRoute]
        [HttpGet]//api/department?id=1?NAme=sd7managerName=ahme           [FromQuery]
        public IActionResult Get1([FromQuery]Department dept)//from route
        {
            return Ok();
        }

    }
}

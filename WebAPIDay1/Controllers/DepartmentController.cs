using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDay1.DTO;
using WebAPIDay1.Models;

namespace WebAPIDay1.Controllers
{
    [Route("api/[controller]")]//URL Resourse (api/Department) + Get
    [ApiController]//filtter api
    public class DepartmentController : ControllerBase//generat response status code
    {
        private readonly ITIContext context;

        public DepartmentController(ITIContext _context)
        {
            
            context = _context;
        }
        //angular postman  (attribute || Method name start with verb)
        //swagger (attribute)

        //api/Department :Get
        
        [HttpGet]
        [Authorize]//filtter check trust or not (token ==>unauthorize)
        public IActionResult GetAll()
        {
            List<DEptDetailsDTO> DEptList = context.Departments
                .Select(d=>new DEptDetailsDTO() { Id=d.Id,Name=d.Name}).ToList();
            //httpresponse
            return Ok(DEptList);//statuscode=200 ,body =List<Department>
        }

        //api/department/8
        [HttpGet("{id:int}")]
        public IActionResult GetByID(int id)
        {
            Department dept=context.Departments.FirstOrDefault(d=>d.Id == id);
            return Ok(dept);
        }

        //api/department/Ahmed
        [HttpGet("{name}")]//verb rout templotae 
        public IActionResult GetByName(string name)
        {
            Department dept = context.Departments.FirstOrDefault(d => d.Name.Contains(name));
            return Ok(dept);
        }

        //api/DEpartment :Post {id:1,na}
        [HttpPost]
        public IActionResult AddDept(Department newDept)//from request body
        {
            if (ModelState.IsValid == true)
            {
                context.Add(newDept);
                context.SaveChanges();
                //  return Created($"http://localhost:5084/api/Department/{newDept.Id}",newDept);//return 201 + url reouse 
                return CreatedAtAction(nameof(GetByID), new { id = newDept.Id },newDept);
                //build url ==> response header "Location:url" 201 resourec add  
            }
            return BadRequest(ModelState);
        }


        //api/DEpartment/1 :PUT (obj)
        [HttpPut]//httpPatch
        public IActionResult Edit(int id, Department updatedDept )
        {
            Department deptFromDb= context.Departments.FirstOrDefault(d => d.Id == id);//track
           
            if(deptFromDb==null)
            {
                return BadRequest("Invalid ID");
            }
            else if(deptFromDb.Id != updatedDept.Id)
            {
                return BadRequest("Invalid ID");

            }
            deptFromDb.Name = updatedDept.Name;
            deptFromDb.ManagerName=updatedDept.ManagerName;
            //context.Update(deptFromDb);
            context.SaveChanges();
            return NoContent();//done 204 Edit / Delete
            //return StatusCode(StatusCodes.Status204NoContent, "Data Save");
        }

        //api/DEpartment :DElete
        [HttpDelete("{id:int}")]
        public IActionResult Remove(int id)
        {
            try
            {
                //soft delete (update)
                Department dept = context.Departments.FirstOrDefault(d => d.Id == id);
                context.Remove(dept);
                context.SaveChanges();
                return NoContent();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIDay1.DTO;
using WebAPIDay1.Models;

namespace WebAPIDay1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ITIContext context;

        public EmployeeController(ITIContext _context)
        {
            context = _context;
        }
        
        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            List<Employee> emp1 = context.Employees.ToList();

            GeneralResponse reposnse = 
                new GeneralResponse() {
                IsPass = true,
                Message = emp1
            };
            return reposnse;//inside httpresponse
        }

        [HttpGet("{name:alpha}")]
        public ActionResult GetByName(string name)
        {
            Employee employee = context.Employees.FirstOrDefault(e=>e.Name == name);
            
            if(employee == null)
            {
                //badreq
                return Ok(new GeneralResponse()
                {
                    IsPass = false,
                    Message =  "Name Not Founs"
                });
            }
            
            return Ok(new GeneralResponse(){
                IsPass = true,
                Message = employee});
        }






        [HttpGet("{id:int}")]//localhost:343/api/Employee/1
        public IActionResult GetByID(int id)
        {
            Employee emp1 = context.Employees.Include(e => e.Department).FirstOrDefault();
            //secure model structure & table structure
            EmpWithDepartmentInfoDTO? emp = 
                context.Employees
                .Include(e => e.Department)
                .Select(e=>new EmpWithDepartmentInfoDTO() 
                    { Salary = e.Salary ,ID=e.Id,DeptName= e.Department.Name,EmpName=e.Name})
                .FirstOrDefault(e => e.ID == id);
            //EmpWithDepartmentInfoDTO empDTO=new EmpWithDepartmentInfoDTO();
            //empDTO.ID = empfromDB.Id;
            //empDTO.EmpName = empfromDB.Name;
            //empDTO.DeptName = empfromDB.Department.Name;
            //empDTO.Salary= empfromDB.Salary;
            //(name, id, salary ,deptName)
            //extra info null
            //cycle
            return Ok(emp);
        }
    }
}

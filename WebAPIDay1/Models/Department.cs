using System.ComponentModel.DataAnnotations;

namespace WebAPIDay1.Models
{
    public class Department
    {
        public int Id { get; set; }
       
        [MinLength(3)]
        public string Name { get; set; }
        
        [Required(ErrorMessage ="MAnager NAme Is Required")]
        public string ManagerName { get; set; }


        public List<Employee>? EmpList { get; set; }
    }
}

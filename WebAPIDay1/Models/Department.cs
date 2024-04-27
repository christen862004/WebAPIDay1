using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPIDay1.Models
{
    public class Department
    {
        public int Id { get; set; }
       
        [MinLength(3)]
        public string Name { get; set; }
        
        [Required(ErrorMessage ="MAnager NAme Is Required")]
        public string ManagerName { get; set; }

        [JsonIgnore]//dotn serialize
        public List<Employee>? EmpList { get; set; }
    }
}

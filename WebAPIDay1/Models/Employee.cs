using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIDay1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }

        [ForeignKey("Department")]
        public int? DeptID { get; set; }//not allow null

        public Department? Department { get; set; }
    }
}

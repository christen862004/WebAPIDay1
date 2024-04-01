using System.ComponentModel.DataAnnotations;

namespace WebAPIDay1.Models
{
    public class Student
    {
        public int Id { get; set; }
        [MinLength(3)]
        [MaxLength(25)]
        public string NAme { get; set; }
    }
}

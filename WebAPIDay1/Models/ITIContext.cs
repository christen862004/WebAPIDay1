using Microsoft.EntityFrameworkCore;

namespace WebAPIDay1.Models
{
    public class ITIContext:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public ITIContext(DbContextOptions options):base(options)
        {
            
        }

    }
}

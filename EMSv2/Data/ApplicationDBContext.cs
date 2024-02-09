using EMSv2.Models;
using Microsoft.EntityFrameworkCore;

namespace EMSv2.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
    }
}

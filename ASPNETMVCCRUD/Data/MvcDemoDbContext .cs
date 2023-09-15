using ASPNETMVCCRUD.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVCCRUD.Data
{
    public class MvcDemoDbContext : DbContext
    {
        
        public MvcDemoDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> employees { get; set; }

    }
}

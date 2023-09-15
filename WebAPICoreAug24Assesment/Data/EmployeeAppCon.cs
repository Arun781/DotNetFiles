using Microsoft.EntityFrameworkCore;
using WebAPICoreAug24Assesment.ModelEntities;

namespace WebAPICoreAug24Assesment.Data
{
    public class EmployeeAppCon : DbContext
    {
        public EmployeeAppCon(DbContextOptions<EmployeeAppCon> options) : base(options) { }
        public System.Data.Entity.DbSet<Department> Departments
        {
            get;
            set;
        }
        public DbSet<EmployeeAngular> Employees
        {
            get;
            set;
        }
    }
}

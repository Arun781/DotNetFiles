using Microsoft.EntityFrameworkCore;
using WebAPICoreAug24Assesment.Data;
using WebAPICoreAug24Assesment.ModelEntities;

namespace WebAPICoreAug24Assesment.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeAppCon _appDBContext;
        public EmployeeRepository(EmployeeAppCon context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<EmployeeAngular>> GetEmployees()
        {
            return await _appDBContext.Employees.ToListAsync();
        }
        public async Task<EmployeeAngular> GetEmployeeByID(int ID)
        {
            return await _appDBContext.Employees.FindAsync(ID);
        }
        public async Task<EmployeeAngular> InsertEmployee(EmployeeAngular objEmployee)
        {
            _appDBContext.Employees.Add(objEmployee);
            await _appDBContext.SaveChangesAsync();
            return objEmployee;
        }
        public async Task<EmployeeAngular> UpdateEmployee(EmployeeAngular objEmployee)
        {
            _appDBContext.Entry(objEmployee).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objEmployee;
        }
        public bool DeleteEmployee(int ID)
        {
            bool result = false;
            var department = _appDBContext.Employees.Find(ID);
            if (department != null)
            {
                _appDBContext.Entry(department).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

    }
}

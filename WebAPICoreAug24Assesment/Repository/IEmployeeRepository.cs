using WebAPICoreAug24Assesment.ModelEntities;

namespace WebAPICoreAug24Assesment.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeAngular>> GetEmployees();
        Task<EmployeeAngular> GetEmployeeByID(int ID);
        Task<EmployeeAngular> InsertEmployee(EmployeeAngular objEmployee);
        Task<EmployeeAngular> UpdateEmployee(EmployeeAngular objEmployee);
        bool DeleteEmployee(int ID);

    }
}

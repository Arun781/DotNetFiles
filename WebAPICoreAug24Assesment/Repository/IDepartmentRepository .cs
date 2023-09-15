using WebAPICoreAug24Assesment.ModelEntities;

namespace WebAPICoreAug24Assesment.Repository
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartment();
        Task<Department> GetDepartmentByID(int ID);
        Task<Department> InsertDepartment(Department objDepartment);
        Task<Department> UpdateDepartment(Department objDepartment);
        bool DeleteDepartment(int ID);

    }
}

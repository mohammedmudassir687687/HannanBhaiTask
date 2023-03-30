using TaskProj.Models;

namespace TaskProj.Data
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
    }
}

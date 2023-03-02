using API1.Models;

namespace API1.Services
{
    public interface IEmployeeService
    {
        Task<bool> CreateEmployee(Employee employee);
        Task<List<Employee>> GetEmployeeList();
        Task<List<Employee>> GetEmployee(int key);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int key);
    }
}

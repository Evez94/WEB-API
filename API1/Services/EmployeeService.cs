using API1.Models;

namespace API1.Services
{
    public class EmployeeService :IEmployeeService
    {
        private readonly IDbService _dbService;

        public EmployeeService(IDbService dbService)
        {
            _dbService = dbService;
        }


        public async Task<bool> CreateEmployee(Employee employee)
        {
            var result =
            await _dbService.EditData(
                "INSERT INTO public.employees (name,surname, age, address, password) VALUES ( @Name,@Surname, @Age, @Address, @Password)",
                employee);
            return true;
        }

        public async Task<List<Employee>> GetEmployeeList()
        {
            var employeeList = await _dbService.GetAll<Employee>("SELECT * FROM public.employees", new { });
            return employeeList;
        }

        public async Task<List<Employee>> GetEmployee(int id)
        {
            var employeeById = await _dbService.GetAll<Employee>("Select FROM public.employees WHERE id=@Id", new { id });
            return employeeById;
        }
        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var updateEmployee =
           await _dbService.EditData(
               "Update public.employees SET name=@Name,surname=@Surname, age=@Age, address=@Address, password=@Password WHERE id=@Id",
               employee);
            return employee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var deleteEmployee = await _dbService.EditData("DELETE FROM public.employees WHERE id=@Id", new { id });
            return true;
        }

       
    }
}

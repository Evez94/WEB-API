        using API1.Models;
using API1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Immutable;

namespace API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        //Get All Employees
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _employeeService.GetEmployeeList();
            return Ok(result);
        }

        // Get Employee By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var result = await _employeeService.GetEmployee(id);
             return Ok();
        }


        // Create Employee 
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            var result = await _employeeService.CreateEmployee(employee);
            return Ok(result);
        }

        // Update Employee 
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            var result = await _employeeService.UpdateEmployee(employee);
            return Ok(result);
        }



        // Delete Employee By Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployee(id);
            return Ok(result);
        }
    }
}

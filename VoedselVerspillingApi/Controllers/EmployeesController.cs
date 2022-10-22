using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace VoedselVerspillingApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeesController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    // CREATE: api/Employees
    [HttpPost]
    public Task<ActionResult<IEnumerable<Employee>>> CreateEmployee()
    {
        return Task.FromResult<ActionResult<IEnumerable<Employee>>>(StatusCode(StatusCodes.Status501NotImplemented, new { message = "Functionality for creating not yet implemented." }));
    }
    
    // GET: api/Employees
    [HttpGet]
    public Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
    {
        if (_employeeRepository.GetEmployees() == null)
        {
            return Task.FromResult<ActionResult<IEnumerable<Employee>>>(NotFound());
        }

        return Task.FromResult<ActionResult<IEnumerable<Employee>>>(_employeeRepository.GetEmployees());
    }
    
    // GET: api/Employees/1
    [HttpGet("{id}")]
    public Task<ActionResult<Employee>> GetEmployees(int id)
    {
        if (_employeeRepository.GetEmployees() == null)
        {
            return Task.FromResult<ActionResult<Employee>>(NotFound());
        }
        var employee = _employeeRepository.GetEmployee(id);

        if (employee == null)
        {
            return Task.FromResult<ActionResult<Employee>>(NotFound());
        }

        return Task.FromResult<ActionResult<Employee>>(employee);
    }

    // UPDATE: api/Employees/1
    [HttpPut("{id}")]
    public Task<ActionResult<IEnumerable<Employee>>> UpdateEmployees(int id)
    {
        return Task.FromResult<ActionResult<IEnumerable<Employee>>>(StatusCode(StatusCodes.Status501NotImplemented, new { message = "Functionality for editing not yet implemented." }));
    }

    // DELETE: api/Employees/1
    [HttpDelete("{id}")]
    public Task<ActionResult<IEnumerable<Employee>>> DeleteEmployees(int id)
    {
        return Task.FromResult<ActionResult<IEnumerable<Employee>>>(StatusCode(StatusCodes.Status501NotImplemented, new { message = "Functionality for deleting not yet implemented." }));
    }
}
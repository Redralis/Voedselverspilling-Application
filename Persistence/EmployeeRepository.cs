using Domain;
using Domain.Services;

namespace Persistence;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void CreateEmployee(Employee? employee)
    {
        if (employee != null) _context.Employee.Add(employee);
        _context.SaveChanges();
    }

    public Employee? GetEmployee(int id)
    {
        return _context.Employee.Find(id);
    }

    public void EditEmployee(Employee employee)
    {
        _context.Employee.Update(employee);
        _context.SaveChanges();
    }

    public void DeleteEmployee(Employee employee)
    {
        _context.Employee.Remove(employee);
        _context.SaveChanges();
    }
    
}
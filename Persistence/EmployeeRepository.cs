using Domain;
using Domain.Services;
using Microsoft.EntityFrameworkCore;

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

    public Employee? GetEmployee(string email)
    {
        return _context.Employee.Include(e => e.Canteen).FirstOrDefault(s => s.Email == email);
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
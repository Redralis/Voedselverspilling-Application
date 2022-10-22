namespace Domain.Services;

public interface IEmployeeRepository
{
    public void CreateEmployee(Employee? employee);
    
    public Employee? GetEmployee(int id);
    
    public Employee? GetEmployeeByEmail(string email);
    
    public List<Employee> GetEmployees();

    public void EditEmployee(Employee employee);

    public void DeleteEmployee(Employee employee);
    
}
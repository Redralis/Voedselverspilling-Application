namespace Domain.Services;

public interface IEmployeeRepository
{
    public void CreateEmployee(Employee? employee);
    
    public Employee? GetEmployee(string email);

    public void EditEmployee(Employee employee);

    public void DeleteEmployee(Employee employee);
    
}
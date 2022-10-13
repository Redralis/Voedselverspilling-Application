namespace Domain.Services;

public interface IEmployeeRepository
{
    public void CreateEmployee(Employee? employee);
    
    public Employee? GetEmployee(int id);

    public void EditEmployee(Employee employee);

    public void DeleteEmployee(Employee employee);
    
}
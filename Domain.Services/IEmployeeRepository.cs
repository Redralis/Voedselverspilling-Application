namespace Domain.Services;

public interface IEmployeeRepository
{
    public Employee CreateEmployee(Employee employee);
    
    public Employee GetEmployee(string email);

    public Employee EditEmployee(Employee employee);

    public Employee DeleteEmployee(string email);
    
}
namespace Domain.Services;

public interface IEmployeeRepository
{
    public Employee CreateEmployee(Employee employee);
    
    public Employee GetEmployee(int id);

    public Employee EditEmployee(Employee employee);

    public Employee DeleteEmployee(int id);
    
}
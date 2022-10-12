namespace Domain.Services;

public interface IStudentRepository
{
    public Student CreateStudent(Student student);
    
    public Student GetStudent(int id);

    public Student EditStudent(Student student);

    public Student DeleteStudent(int id);
    
}
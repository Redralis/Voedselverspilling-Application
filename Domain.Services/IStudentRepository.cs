namespace Domain.Services;

public interface IStudentRepository
{
    public void CreateStudent(Student? student);
    
    public Student? GetStudent(string email);

    public void EditStudent(Student student);

    public void DeleteStudent(Student student);
    
}
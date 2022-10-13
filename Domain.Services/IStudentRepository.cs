namespace Domain.Services;

public interface IStudentRepository
{
    public void CreateStudent(Student? student);
    
    public Student? GetStudent(int id);

    public void EditStudent(Student student);

    public void DeleteStudent(Student student);
    
}
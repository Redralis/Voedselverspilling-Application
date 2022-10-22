namespace Domain.Services;

public interface IStudentRepository
{
    public void CreateStudent(Student? student);
    
    public Student? GetStudent(int id);
    
    public Student? GetStudentByEmail(string email);
    
    public List<Student> GetStudents();

    public void EditStudent(Student student);

    public void DeleteStudent(Student student);
    
}
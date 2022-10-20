using Domain;
using Domain.Services;

namespace Persistence;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _context;

    public StudentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void CreateStudent(Student? student)
    {
        if (student != null) _context.Student.Add(student);
        _context.SaveChanges();
    }

    public Student? GetStudent(string email)
    {
        return _context.Student.FirstOrDefault(s => s.Email == email);
    }

    public void EditStudent(Student student)
    {
        _context.Student.Update(student);
        _context.SaveChanges();
    }

    public void DeleteStudent(Student student)
    {
        _context.Student.Remove(student);
        _context.SaveChanges();
    }
}
using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace VoedselVerspillingApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public StudentsController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    // CREATE: api/Students
    [HttpPost]
    public Task<ActionResult<IEnumerable<Student>>> CreateStudent()
    {
        return Task.FromResult<ActionResult<IEnumerable<Student>>>(StatusCode(StatusCodes.Status501NotImplemented, new { message = "Functionality for creating not yet implemented." }));
    }
    
    // GET: api/Students
    [HttpGet]
    public Task<ActionResult<IEnumerable<Student>>> GetStudents()
    {
        return Task.FromResult<ActionResult<IEnumerable<Student>>>(_studentRepository.GetStudents());
    }
    
    // GET: api/Students/1
    [HttpGet("{id}")]
    public Task<ActionResult<Student>> GetStudents(int id)
    {
        var student = _studentRepository.GetStudent(id);
        return student == null ? Task.FromResult<ActionResult<Student>>(NotFound()) : Task.FromResult<ActionResult<Student>>(student);
    }

    // UPDATE: api/Students/1
    [HttpPut("{id}")]
    public Task<ActionResult<IEnumerable<Student>>> UpdateStudents(int id)
    {
        return Task.FromResult<ActionResult<IEnumerable<Student>>>(StatusCode(StatusCodes.Status501NotImplemented, new { message = "Functionality for editing not yet implemented." }));
    }

    // DELETE: api/Students/1
    [HttpDelete("{id}")]
    public Task<ActionResult<IEnumerable<Student>>> DeleteStudents(int id)
    {
        return Task.FromResult<ActionResult<IEnumerable<Student>>>(StatusCode(StatusCodes.Status501NotImplemented, new { message = "Functionality for deleting not yet implemented." }));
    }
}
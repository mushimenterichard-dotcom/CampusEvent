using Microsoft.AspNetCore.Mvc;
using CampusEvents.Api.Model;

namespace CampusEvents.Api.Controllers;

[ApiController]
[Route("api/students")]

public class StudentsController : ControllerBase
{
    private readonly List<Student> _student = new List<Student>()
    {
        new Student { Id = 1, Name = "Alice Johnson", Email = "alice.johnson@university.edu", EnrollmentDate = new DateTime(2023, 9, 1) },
        new Student { Id = 2, Name = "Bob Smith", Email = "bob.smith@university.edu", EnrollmentDate = new DateTime(2023, 9, 1) },
        new Student { Id = 3, Name = "Charlie Brown", Email = "charlie.brown@university.edu", EnrollmentDate = new DateTime(2023, 9, 1) }
    };

    [HttpGet]

    public ActionResult<IEnumerable<Student>> GetStudents()
    {
        return Ok(_student);
    }
}
using Microsoft.AspNetCore.Mvc;

namespace CampusEvents.Api.Model;


[Route("api/students")]
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime EnrollmentDate { get; set; }
}
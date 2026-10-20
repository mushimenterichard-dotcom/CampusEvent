using Microsoft.AspNetCore.Mvc;

namespace CampusEvents.Api.Model;

[Route("api/speakers")]
public class Speaker
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Bio { get; set; }
    public string Email { get; set; }
}
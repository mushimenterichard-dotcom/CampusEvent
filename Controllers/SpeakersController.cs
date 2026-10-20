using Microsoft.AspNetCore.Mvc;
using CampusEvents.Api.Model;

namespace CampusEvents.Api.Controllers;


[ApiController]
[Route("api/speakers")]

public class SpeakersController : ControllerBase

{
    private readonly List<Speaker> _speakers = new List<Speaker>()
    {
        new Speaker { Id = 1, Name = "John Doe", Bio = "Expert in AI and Machine Learning." },
        new Speaker { Id = 2, Name = "Jane Smith", Bio = "Renowned artist and curator." },
        new Speaker { Id = 3, Name = "Mike Johnson", Bio = "Professional musician and composer." }
    };


    [HttpGet]
    public ActionResult<IEnumerable<Speaker>> GetSpeakers()
    {
        return Ok(_speakers);
    }
}
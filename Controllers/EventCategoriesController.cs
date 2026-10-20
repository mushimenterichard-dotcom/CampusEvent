using Microsoft.AspNetCore.Mvc;
using CampusEvents.Api.Model;

namespace CampusEvents.Api.Controllers;

[ApiController]
[Route("api/eventcategories")]

public class EventCategoriesController : ControllerBase
{
    private readonly List<EventCategory> _eventCategory = new List<EventCategory>()
    {
        new EventCategory { Id = 1, Name = "Conference" },
        new EventCategory { Id = 2, Name = "Workshop" },
        new EventCategory { Id = 3, Name = "Seminar" }
    };

    [HttpGet]

    public ActionResult<IEnumerable<EventCategory>> GetEventCategories ()
    {
        return Ok(_eventCategory); 
    }
}
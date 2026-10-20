using Microsoft.AspNetCore.Mvc;
using CampusEvents.Api.Data;
using CampusEvents.Api.Dtos;
using CampusEvents.Api.Model;

namespace CampusEvents.Api.Controllers;

[ApiController]
[Route("api/events")]
public class EventsController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public EventsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CampusEvent>> GetEvents()
    {
        var events = _dbContext.CampusEvents.ToList();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public ActionResult<CampusEvent> GetEvent(int id)
    {
        var campusEvent = _dbContext.CampusEvents.FirstOrDefault(e => e.Id == id);
        if (campusEvent == null)
        {
            return NotFound(new { message = $"Event with ID {id} not found." });
        }

        return Ok(campusEvent);
    }

    [HttpPost]
    public ActionResult<CampusEvent> CreateEvent([FromBody] EventCreateDto eventCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var newEvent = new CampusEvent
        {
            Name = eventCreateDto.Name,
            StartDate = eventCreateDto.StartDate,
            EndDate = eventCreateDto.EndDate,
            Location = eventCreateDto.Location,
            Organizer = eventCreateDto.Organizer,
        };

        _dbContext.CampusEvents.Add(newEvent);
        _dbContext.SaveChanges();

        return CreatedAtAction(nameof(GetEvent), new { id = newEvent.Id }, newEvent);
    }

    [HttpPut("{id}")]
    public ActionResult<CampusEvent> UpdateEvent(int id, [FromBody] EventCreateDto eventUpdateDto)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var campusEvent = _dbContext.CampusEvents.FirstOrDefault(e => e.Id == id);
        if (campusEvent == null)
        {
            return NotFound(new { message = $"Event with ID {id} not found." });
        }

        campusEvent.Name = eventUpdateDto.Name;
        campusEvent.StartDate = eventUpdateDto.StartDate;
        campusEvent.EndDate = eventUpdateDto.EndDate;
        campusEvent.Location = eventUpdateDto.Location;
        campusEvent.Organizer = eventUpdateDto.Organizer;
        _dbContext.SaveChanges();

        return Ok(campusEvent);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteEvent(int id)
    {
        var campusEvent = _dbContext.CampusEvents.FirstOrDefault(e => e.Id == id);
        if (campusEvent == null)
        {
            return NotFound(new { message = $"Event with ID {id} not found." });
        }

        _dbContext.CampusEvents.Remove(campusEvent);
        _dbContext.SaveChanges();

        return NoContent();
    }
}
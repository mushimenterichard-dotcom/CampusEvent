using Microsoft.AspNetCore.Mvc;

namespace CampusEvents.Api.Model;

[Route("api/eventcategories")]
public class EventCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
}

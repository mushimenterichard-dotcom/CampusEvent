using System.ComponentModel.DataAnnotations;

namespace CampusEvents.Api.Dtos
{
    public class EventResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }
    }
    public class EventCreateDto
    {
        [Required, MaxLength(100 , ErrorMessage = "Name must be between 3 and 100 characters long.") , MinLength(3)]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Required, MaxLength(200), MinLength(3)]
        public string Location { get; set; }

        [Required, MaxLength(100), MinLength(3)]
        public string Organizer { get; set; }
    }
}
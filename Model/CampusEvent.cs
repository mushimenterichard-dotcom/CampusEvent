 using Microsoft.AspNetCore.Mvc;

 namespace CampusEvents.Api.Model;
 public class CampusEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }
    }
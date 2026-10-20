namespace CampusEvents.Api.Data;

using CampusEvents.Api.Model;

public class DbSeeder
{

    public static void SeedDatabase(AppDbContext context)
    {
        if (!context.CampusEvents.Any())
        {
            var events = new List<CampusEvent>
            {
                new CampusEvent
                {
                    Name = "Spring Festival",
                    StartDate = DateTime.UtcNow.AddDays(7),
                    EndDate = DateTime.UtcNow.AddDays(8),
                    Location = "Campus Grounds",
                    Organizer = "Student Council"
                },
                new CampusEvent
                {
                    Name = "Tech Talk Series",
                    StartDate = DateTime.UtcNow.AddDays(12),
                    EndDate = DateTime.UtcNow.AddDays(14),
                    Location = "Auditorium A",
                    Organizer = "Computer Science Department"
                }
            };

            context.CampusEvents.AddRange(events);
            context.SaveChanges();
        }
    }
}
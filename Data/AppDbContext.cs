using Microsoft.EntityFrameworkCore;
using CampusEvents.Api.Model;



namespace CampusEvents.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    } 
    public DbSet<CampusEvent> CampusEvents { get; set; }
}
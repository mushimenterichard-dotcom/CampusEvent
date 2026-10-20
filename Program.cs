using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using CampusEvents.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Register the DbContext with the connection string from appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Recreate the local SQLite database when the app schema changes so the dev database
    // stays aligned with the current EF model and seeded data.
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();

    //seed the database with initial data
    DbSeeder.SeedDatabase(dbContext);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();// This will generate the OpenAPI specification for the API endpoints
    app.MapScalarApiReference();//scalar reference
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

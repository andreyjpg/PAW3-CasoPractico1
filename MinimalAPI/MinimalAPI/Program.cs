using Microsoft.EntityFrameworkCore;
using MinimalAPI.Context;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register your DbContext with the connection string
builder.Services.AddDbContext<ITSupportDbContext>(options =>
    options.UseSqlServer(connectionString));
var app = builder.Build();



app.MapGet("/api/tasks", async (ITSupportDbContext db) =>
    await db.Tickets.ToListAsync());

app.Run();

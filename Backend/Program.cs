using Backend.Data;
using Microsoft.EntityFrameworkCore;

// service registration
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
{
   options.UseSqlite("Data Source=contactmanager.db");

   options.ConfigureWarnings(warnings => 
      warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
});

builder.Services.AddControllers();

// app configuration
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.Run();

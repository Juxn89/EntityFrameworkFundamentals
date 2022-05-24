using efFundamentals.Context;
using efFundamentals.enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TasksDBContext>(p => p.UseInMemoryDatabase("TasksDB"));
string connectionString = builder.Configuration.GetConnectionString("TasksDB");
builder.Services.AddSqlServer<TasksDBContext>(connectionString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbConnection", async ([FromServices] TasksDBContext dbContext) => {
    dbContext.Database.EnsureCreated();
    return Results.Ok($"DB in memory: { dbContext.Database.IsInMemory() }");
});

app.MapGet("/api/tasks", async ([FromServices] TasksDBContext dbContext) => {
    // var data = dbContext.Tasks; /* Returns a list of all tasks */
    // var data = dbContext.Tasks.Where(a => a.Priority == Priority.Low); /* Returns a filtered list of task with priority is low */
    var data = dbContext.Tasks.Include(a => a.Category).Where(a => a.Priority == Priority.Low); /* Return a filtered list of task with priority is low and include the category associated */
    return Results.Ok(data);
});

app.MapGet("/api/task/priority/{id}", async ([FromServices] TasksDBContext dbContext, int id) => {
    var data = dbContext.Tasks.Include(a => a.Category).Where(a => (int)a.Priority == id);
    return Results.Ok(data);
});

app.Run();

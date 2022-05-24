using efFundamentals.Context;
using efFundamentals.enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using efFundamentals.Models;

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

app.MapGet("/api/task", async ([FromServices] TasksDBContext dbContext) => {
    // var data = dbContext.Tasks; /* Returns a list of all tasks */
    // var data = dbContext.Tasks.Where(a => a.Priority == Priority.Low); /* Returns a filtered list of task with priority is low */
    var data = dbContext.Tasks.Include(a => a.Category).Where(a => a.Priority == Priority.Low); /* Return a filtered list of task with priority is low and include the category associated */
    return Results.Ok(data);
});

app.MapGet("/api/task/priority/{id}", async ([FromServices] TasksDBContext dbContext, int id) => {
    var data = dbContext.Tasks.Include(a => a.Category).Where(a => (int)a.Priority == id);
    return Results.Ok(data);
});

app.MapPost("/api/task/", async ([FromServices] TasksDBContext dbContext, [FromBody] efFundamentals.Models.Task task) => {
    task.Id = new Guid();
    task.CreationDate = DateTime.Now.Date;

    await dbContext.AddAsync<efFundamentals.Models.Task>(task);
    await dbContext.SaveChangesAsync();

    return Results.Ok(task);
});



app.MapPut("/api/task/{id}", async ([FromServices] TasksDBContext dbContext, [FromBody] efFundamentals.Models.Task task, [FromRoute] Guid id) => {
    var data = dbContext.Tasks.Find(id);

    if(data == null)
        return Results.NotFound("Task not found.");
        
    data.Title = task.Title;
    data.Description = task.Description;
    data.Priority = task.Priority;

    dbContext.Update<efFundamentals.Models.Task>(task);
    await dbContext.SaveChangesAsync();

    return Results.Ok(task);
});

app.Run();

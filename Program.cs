using efFundamentals.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TasksDBContext>(p => p.UseInMemoryDatabase("TasksDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbConnection", async ([FromServices] TasksDBContext dbContext) => {
    dbContext.Database.EnsureCreated();
    return Results.Ok($"DB in memory: { dbContext.Database.IsInMemory() }");
});

app.Run();

using Microsoft.EntityFrameworkCore;
using efFundamentals.Models;

namespace efFundamentals.Context;

public class TasksDBContext : DbContext {
    public TasksDBContext(DbContextOptions<TasksDBContext> options) : base(options) { }

    public DbSet<Models.Task> Tasks {get; set;}
    public DbSet<Category> Categories {get; set;}
}
using Microsoft.EntityFrameworkCore;
using efFundamentals.Models;

namespace efFundamentals.Context;

public class TasksDBContext : DbContext {
    public TasksDBContext(DbContextOptions<TasksDBContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Category>(category => {
            category.ToTable("Category");
            category.HasKey(k => k.Id);
            category.Property(p => p.Name).IsRequired().HasMaxLength(150);
            category.Property(p => p.Description);
            category.Property(p => p.Weight);
        });

        modelBuilder.Entity<Models.Task>(task => {
            task.ToTable("Task");
            task.HasKey(p => p.Id);
            task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
            task.Property(p => p.Title).IsRequired().HasMaxLength(200);
            task.Property(p => p.Description);
            task.Property(p => p.Priority);
            task.Property(p => p.CreationDate);
            task.Ignore(p => p.Summary);
        });
    }

    public DbSet<Models.Task> Tasks {get; set;}
    public DbSet<Category> Categories {get; set;}
}
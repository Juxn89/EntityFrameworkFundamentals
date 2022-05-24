using Microsoft.EntityFrameworkCore;
using efFundamentals.Models;
using efFundamentals.enums;

namespace efFundamentals.Context;

public class TasksDBContext : DbContext {
    public TasksDBContext(DbContextOptions<TasksDBContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Category>(category => {
            category.ToTable("Category");
            category.HasKey(k => k.Id);
            category.Property(p => p.Name).IsRequired().HasMaxLength(150);
            category.Property(p => p.Description).IsRequired(false);
            category.Property(p => p.Weight);

            category.HasData(CategoriesSeed());
        });

        modelBuilder.Entity<Models.Task>(task => {
            task.ToTable("Task");
            task.HasKey(p => p.Id);
            task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
            task.Property(p => p.Title).IsRequired().HasMaxLength(200);
            task.Property(p => p.Description).IsRequired(false);
            task.Property(p => p.Priority);
            task.Property(p => p.CreationDate);
            task.Ignore(p => p.Summary);

            task.HasData(TasksSeed());
        });
    }

    public DbSet<Models.Task> Tasks {get; set;}
    public DbSet<Category> Categories {get; set;}

    #region Seed
    private IEnumerable<Category> CategoriesSeed() {
        List<Category> categoryList = new List<Category>();
        categoryList.Add(new Category{ 
            Id = Guid.Parse("10be4d76-8e50-4606-8628-ce9aede5cdf2"),
            Name = "Pending activities",
            Weight = 20
        });

        categoryList.Add(new Category{ 
            Id = Guid.Parse("10be4d76-8e50-4606-8628-ce9aede5cdf3"),
            Name = "Personal activities",
            Weight = 50
        });

        return categoryList;
    }
    
    private IEnumerable<Models.Task> TasksSeed() {
        List<Models.Task> taskList = new List<Models.Task>();
        taskList.Add(new Models.Task {
            Id = Guid.Parse("10be4d76-8e50-4606-8628-ce9aede5cd10"),
            CategoryId = Guid.Parse("10be4d76-8e50-4606-8628-ce9aede5cdf2"),
            Title = "Paymente of public sercices",
            CreationDate = DateTime.Now.Date,
            Priority = Priority.Medium
        });

        taskList.Add(new Models.Task {
            Id = Guid.Parse("10be4d76-8e50-4606-8628-ce9aede5cd20"),
            CategoryId = Guid.Parse("10be4d76-8e50-4606-8628-ce9aede5cdf3"),
            Title = "Finish watching movie on Netflix",
            CreationDate = DateTime.Now.Date,
            Priority = Priority.Low
        });


        return taskList;
    }
    #endregion
}
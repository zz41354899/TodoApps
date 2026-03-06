using Microsoft.EntityFrameworkCore;
using TodoApps.Models;

namespace TodoApps.Data;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Priority).HasMaxLength(20);
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Icon).HasMaxLength(10);
            entity.Property(e => e.Tags).HasMaxLength(500);
            entity.Property(e => e.RecurringType).HasMaxLength(20);
            entity.Property(e => e.AssignedTo).HasMaxLength(100);
            entity.Property(e => e.Notes).HasMaxLength(2000);
            
            // 配置子任務自我參照關聯
            entity.HasOne(e => e.Parent)
                .WithMany(e => e.SubTasks)
                .HasForeignKey(e => e.ParentId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}

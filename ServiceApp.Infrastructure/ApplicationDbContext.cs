using Microsoft.EntityFrameworkCore;
using ServiceApp.Domain.Tasks;
using ServiceApp.Domain.ToDoItems;

namespace ServiceApp.Infrastructure;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ToDoItem> ToDoItems { get; set; }
    public DbSet<TaskToDo> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TaskToDo>(entity =>
        {
            entity.Property(e => e.Amount)
                  .HasColumnType("decimal(9,2)"); // Specify the precision and scale
        });
    }
}

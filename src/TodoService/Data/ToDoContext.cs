
using Microsoft.EntityFrameworkCore;
using TodoService.Data.Entities;

namespace TodoService;
public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
    {
        Database.Migrate();
    }
    public DbSet<ToDoItem> TodoItem { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDoItem>()
            .HasKey(b => b.Id);


        modelBuilder.Entity<ToDoItem>()
            .Property(b => b.Name)
            .HasMaxLength(128)
            .IsRequired();
    }
}

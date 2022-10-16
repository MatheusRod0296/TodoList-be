using Microsoft.EntityFrameworkCore;
using TodoList.Api.Domain.Models;

namespace TodoList.Api.Domain;

public class TodoListContext: DbContext
{
    public TodoListContext(DbContextOptions<TodoListContext> options)
        : base(options) {}
    public DbSet<User> Users { get; set; }
    public DbSet<TodoTask> Tasks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(b => b.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<TodoTask>()
            .Property(b => b.Id)
            .ValueGeneratedOnAdd();
    }
}
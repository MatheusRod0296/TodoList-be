using TodoList.Api.Domain.Enums;

namespace TodoList.Api.Domain.Models;

public class TodoTask
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime DeadLine { get; set; }
    public DateTime? DoneAt { get; set; }
    public bool Done { get; set; }
    public Priority Priority { get; set; }
    
    public int UserId { get; set; }
}
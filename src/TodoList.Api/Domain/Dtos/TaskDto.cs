using TodoList.Api.Domain.Enums;

namespace TodoList.Api.Domain.Dtos;

public class TaskDto
{
    public string Name { get; set; }
    public string Description { get; set; }   
    public DateTime DeadLine { get; set; }
    public Priority Priority { get; set; }
}
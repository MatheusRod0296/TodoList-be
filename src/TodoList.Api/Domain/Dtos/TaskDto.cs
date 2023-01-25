using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TodoList.Api.Domain.Enums;

namespace TodoList.Api.Domain.Dtos;

public class TaskDto
{
    /// <summary>
    ///  Nome da tarefa
    /// </summary>
    [Description("nome da terafa")]
    public string Name { get; set; }
    public string Description { get; set; }   
    public DateTime DeadLine { get; set; }
    public Priority Priority { get; set; }
}
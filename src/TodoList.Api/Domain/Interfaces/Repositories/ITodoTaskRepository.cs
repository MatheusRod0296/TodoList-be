using TodoList.Api.Domain.Models;

namespace TodoList.Api.Domain.Interfaces.Repositories;

public interface ITodoTaskRepository
{
    Task<bool> Create(TodoTask task);
    Task<List<TodoTask>> Get(int idUser);
}
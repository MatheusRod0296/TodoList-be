using Microsoft.EntityFrameworkCore;
using TodoList.Api.Domain;
using TodoList.Api.Domain.Interfaces.Repositories;
using TodoList.Api.Domain.Models;

namespace TodoList.Api.Repositories;

public class TodoTaskRepository: ITodoTaskRepository
{
    private readonly TodoListContext _context;

    public TodoTaskRepository(TodoListContext context)
    {
        _context = context;
    }

    public async Task<bool> Create(TodoTask task)
    {
        _context.Tasks.Add(task);
        return await _context.SaveChangesAsync() > 0;
    }

    public Task<List<TodoTask>> Get(int idUser)
        => _context.Tasks.Where(x => x.UserId == idUser).ToListAsync();
}


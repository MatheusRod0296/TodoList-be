using Microsoft.EntityFrameworkCore;
using TodoList.Api.Domain;
using TodoList.Api.Domain.Interfaces.Repositories;
using TodoList.Api.Domain.Models;
using Task = System.Threading.Tasks.Task;

namespace TodoList.Api.Repositories;

public class UserRepository: IUserRepository
{
    private readonly TodoListContext _context;

    public UserRepository(TodoListContext context)
    {
        _context = context;
    }

    public async Task<User> Get(string username, string password)
        => await _context.Users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefaultAsync();

    public Task<int?> GetIdByUserName(string userName)
    {
       var id = _context.Users.Where(x => x.Username == userName).FirstOrDefault()?.Id;
       return Task.FromResult(id);
    }

    public async Task<bool> Create(User user)
    {
        _context.Users.Add(user);
        return await _context.SaveChangesAsync() > 0;
    }
}
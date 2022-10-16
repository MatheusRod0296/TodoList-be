using TodoList.Api.Domain.Models;

namespace TodoList.Api.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User> Get(string username, string password);

    Task<int?> GetIdByUserName(string userName);

    Task<bool> Create(User user);
}
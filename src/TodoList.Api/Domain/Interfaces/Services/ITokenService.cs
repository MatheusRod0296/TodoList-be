using TodoList.Api.Domain.Models;

namespace TodoList.Api.Domain.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}
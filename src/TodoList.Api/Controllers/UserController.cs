using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Domain.Interfaces.Repositories;
using TodoList.Api.Domain.Models;

namespace TodoList.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Create([Description("nome do usuario")]string userName, string password)
    {
        var user = new User
        {
            Username = userName,
            Password = password,
            Role = "User"
        };

        return await _userRepository.Create(user);
    }
}
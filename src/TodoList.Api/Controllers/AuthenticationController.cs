using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Domain.Interfaces.Repositories;
using TodoList.Api.Domain.Interfaces.Services;
using TodoList.Api.Domain.Models;

namespace TodoList.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController: ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    
    public AuthenticationController(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Authenticate(string userName, string password)
    {
        var user = await _userRepository.Get(userName, password);
        
        if (user == null)
            return NotFound(new { message = "Usuário ou senha inválidos" });

        var token = _tokenService.GenerateToken(user);

        user.Password = "";

        return new{user, token};
    }
}
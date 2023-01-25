using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Domain.Dtos;
using TodoList.Api.Domain.Interfaces.Repositories;
using TodoList.Api.Domain.Models;

namespace TodoList.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController: ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _userRepository;
    private readonly ITodoTaskRepository _todoTaskRepository;

    public TaskController(IHttpContextAccessor httpContextAccessor,
        IUserRepository userRepository,
        ITodoTaskRepository todoTaskRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _userRepository = userRepository;
        _todoTaskRepository = todoTaskRepository;
    }

    /// <summary>
    /// Cria uma nova tarefa.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Create
    ///     {        
    ///        "Nome": "Send documents",
    ///        "description": "Send a copy of Rg to PoupaTempo",
    ///        "DeadLine": "2023-01-30",
    ///        "Priority": 3
    ///     }
    ///
    /// </remarks>
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<dynamic>> Create([FromBody] TaskDto taskDto)
    {
        var userName = _httpContextAccessor?.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        var idUser = await _userRepository.GetIdByUserName(userName);

        if (idUser == null)
            return BadRequest();

        var todoTask = new TodoTask
        {
            UserId = idUser.Value,
            Name = taskDto.Name,
            Description = taskDto.Description,
            CreateAt = DateTime.Now,
            DeadLine = taskDto.DeadLine,
            DoneAt = null,
            Done = false,
            Priority = taskDto.Priority
        };

        var result = await _todoTaskRepository.Create(todoTask);

        return result ? Ok() : BadRequest();
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<TodoTask>>> Get()
    {
        var userName = _httpContextAccessor?.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        var idUser = await _userRepository.GetIdByUserName(userName);

        if (idUser == null)
            return BadRequest();
        
       return await _todoTaskRepository.Get(idUser.Value);
    }
}
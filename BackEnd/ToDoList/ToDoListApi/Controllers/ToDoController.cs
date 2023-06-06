using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.Constants;
using ToDoList.Application.Models.ToDo;

namespace ToDoList.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IToDoService _todoService;
        private readonly ClaimsPrincipal _user;
        private readonly int _userId;

        public TodosController(IToDoService todoService, IHttpContextAccessor httpContextAccessor)
        {
            _todoService = todoService;
            _user = httpContextAccessor.HttpContext.User;
            Int32.TryParse(_user.Identity.Name, out _userId);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (_user.IsInRole(Roles.SuperAdmin))
            {
                return Ok(await _todoService.GetToDosAsync(null));
            }
            return Ok(await _todoService.GetToDosAsync(_userId));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateToDoDTO createTodoDTO)
        {
            if (_user.IsInRole(Roles.SuperAdmin))
            {
                return Ok(_todoService.CreateToDo(createTodoDTO));
            }
            createTodoDTO.UserId = _userId;
            return Ok(await _todoService.GetToDosAsync(_userId));
        }
    }
}

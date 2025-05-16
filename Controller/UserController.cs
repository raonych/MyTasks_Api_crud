using Microsoft.AspNetCore.Mvc;
using MyTasks.Interfaces;
using MyTasks.Models;
namespace MyTasks.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly InterfaceUserService _service;

        public UserController(InterfaceUserService service) => _service = service;


        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllUsers());
    }
} 

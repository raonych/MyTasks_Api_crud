using Microsoft.AspNetCore.Mvc;
using MyTasks.Interfaces;
using MyTasks.Models;
namespace MyTasks.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly InterfaceUserService _service;

        public UserController(InterfaceUserService service) => _service = service;


        [HttpGet]
        public async Task<ActionResult<ResponseModel<IEnumerable<User>>>> GetAll()
        {
            var users = await _service.GetAllUsers();
            return StatusCode(users.Status, users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<User>>> GetUserById([FromRoute] int id)
        {
            var user = await _service.GetUserById(id);

            return StatusCode(user.Status, user);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<User>>> CreateUser([FromBody] User body)
        {
            var user = await _service.CreateUser(body); 
           
           return StatusCode(user.Status, user);
        }
    }
} 

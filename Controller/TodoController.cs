using Microsoft.AspNetCore.Mvc;
using MyTasks.DTOs;
using MyTasks.Interfaces;
using MyTasks.Models;

namespace MyTasks.Controller
{

    [ApiController]
    [Route("api/[Controller]")]
    public class TodoController : ControllerBase
    {
        private readonly InterfaceTodoService _service;

        public TodoController(InterfaceTodoService service) => _service = service;


        [HttpGet("fromUser/{id}")]
        public async Task<ActionResult<ResponseModel<Todo>>> GetTodosByUserId([FromRoute] int id)
        {
            var todos = await _service.GetTodosByUserId(id);

            return StatusCode(todos.Status, todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<Todo>>> GetTodoById([FromRoute] int id)
        {
            var todo = await _service.GetTodoById(id);
            return StatusCode(todo.Status, todo);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<ResponseModel<Todo>>> CreateTodo([FromBody] CreateTodoDto body, [FromRoute] int id)
        {
            var todo = await _service.CreateTodo(id, body);

            return StatusCode(todo.Status, todo);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<ResponseModel<Todo>>> UpdateTodo([FromBody] Todo body, [FromRoute] int id)
        {
            var updatedTodo = await _service.UpdateTodo(id, body);

            return StatusCode(updatedTodo.Status, updatedTodo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<Todo>>> DeleteTodo([FromBody] Todo body, [FromRoute] int id)
        {
            var deletedTodo = await _service.DeleteTodo(id);

            return StatusCode(deletedTodo.Status, deletedTodo);
        }
    }
}
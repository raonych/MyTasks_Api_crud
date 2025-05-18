using MyTasks.DTOs;
using MyTasks.Models;

namespace MyTasks.Interfaces
{

    public interface InterfaceTodoService
    {
        Task<ResponseModel<IEnumerable<Todo>>> GetTodosByUserId(int userId);
        Task<ResponseModel<Todo?>> GetTodoById(int id);
        Task<ResponseModel<Todo>> CreateTodo(int userId, CreateTodoDto Todo);
        Task<ResponseModel<Todo?>> UpdateTodo(int id, Todo todo);
        Task<ResponseModel<bool>> DeleteTodo(int id);
    }


}
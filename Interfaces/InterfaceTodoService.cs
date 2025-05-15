using MyTasks.Models;

namespace MyTasks.Interfaces
{

    public interface InterfaceTodoService
    {
        Task<IEnumerable<Todo>> GetTodosByUserId(int userId);
        Task<Todo?> GetTodoById(int id);
        Task<Todo> CreateTodo(int userId, Todo todo);
        Task<Todo?> UpdateTodo(int id, Todo todo);
        Task<bool> DeleteTodo(int id);
    }


}
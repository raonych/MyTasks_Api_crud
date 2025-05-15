using Microsoft.EntityFrameworkCore;
using MyTasks.Models;
using MyTasks.Interfaces;
using MyTasks.Data;

namespace MyTasks.Services
{

    public class TodoService : InterfaceTodoService
    {
        private readonly AppDbContext _context;

        public TodoService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Todo>> GetTodosByUserId(int userId) =>
            await _context.Todo.Where(todo => todo.UserId == userId).ToListAsync();

        public async Task<Todo?> GetTodoById(int id) =>

        await _context.Todo.Include(todo => todo.User).FirstOrDefaultAsync(todo => todo.Id == id);

        public async Task<Todo> CreateTodo(int userId, Todo todo)
        {
            todo.UserId = userId;
            _context.Todo.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo?> UpdateTodo(int id, Todo updated)
        {
            var todo = await _context.Todo.FindAsync(id);
            if (todo is null) return null;
            todo.Title = updated.Title;
            todo.Done = updated.Done;
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<bool> DeleteTodo(int id)
        {
            var todo = await _context.Todo.FindAsync(id);
            if (todo is null) return false;
            _context.Todo.Remove(todo);
            await _context.SaveChangesAsync();
            return true;             
        }  
    }    

}
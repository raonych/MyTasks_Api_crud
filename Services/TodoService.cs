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

        public async Task<ResponseModel<IEnumerable<Todo>>> GetTodosByUserId(int userId)
        {
            ResponseModel<IEnumerable<Todo>> response = new();
            try
            {
                var todos = await _context.Todo.Where(todo => todo.UserId == userId).ToListAsync();
                if (todos.Count == 0)
                {
                    response.Data = null;
                    response.Message = "Este usuário não possui nenhuma tarefa";
                    response.Success = true;

                    return response;
                }

                response.Data = todos;
                response.Message = "Tarefas do usuário";
                response.Success = true;

                return response;

            }
            catch (Exception error)
            {
                response.Data = null;
                response.Message = error.Message;
                response.Success = false;

                return response;
            }
             
         }


        public async Task<ResponseModel<Todo?>> GetTodoById(int id) { 
            ResponseModel<Todo?> response = new();
            try
            {
                var todo = await _context.Todo.Include(todo => todo.User).FirstOrDefaultAsync(todo => todo.Id == id);
                if (todo is null)
                {
                    response.Data = null;
                    response.Message = "Tarefa não encontrada";
                    response.Success = false;

                    return response;
                }

                response.Data = todo;
                response.Message = "Retornando tarefa";
                response.Success = true;

                return response;

            }
            catch (Exception error)
            {
                response.Data = null;
                response.Message = error.Message;
                response.Success = false;

                return response;
            }
            
        }

        public async Task<ResponseModel<Todo>> CreateTodo(int userId, Todo todo)
        {
            ResponseModel<Todo> response = new();
            try
            {
                todo.UserId = userId;
                _context.Todo.Add(todo);
                await _context.SaveChangesAsync();

                response.Data = todo;
                response.Message = "Tarefa registrada com sucesso";
                response.Success = false;

                return response;
            }
            catch (Exception error)
            {
                response.Data = todo;
                response.Message = error.Message;
                response.Success = false;

                return response;
            }
            

        }

        public async Task<ResponseModel<Todo?>> UpdateTodo(int id, Todo updated)
        {
            ResponseModel<Todo?> response = new();
            try
            {
                var todo = await _context.Todo.FindAsync(id);
                if (todo is null)
                {
                    response.Data = null;
                    response.Message = "Tarefa não encontrada";
                    response.Success = false;
                    return response;
                }


                todo.Title = updated.Title;
                todo.Done = updated.Done;
                await _context.SaveChangesAsync();

                response.Data = updated;
                response.Message = "Tarefa atualizada com sucesso";
                response.Success = true;

                return response;

            }
            catch (Exception error)
            {
                response.Data = updated;
                response.Message = error.Message;
                response.Success = false;

                return response;
            }
            
        }

        public async Task<ResponseModel<bool>> DeleteTodo(int id)
        {
            ResponseModel<bool> response = new();
            try
            {
                var todo = await _context.Todo.FindAsync(id);
                if (todo is null)
                {
                    response.Data = false;
                    response.Message = "Tarefa não encontrada";
                    response.Success = false;

                    return response;
                }

                _context.Todo.Remove(todo);
                await _context.SaveChangesAsync();

                response.Data = true;
                response.Message = "Tarefa deletada com sucesso";
                response.Success = true;

                return response;
            }
            catch (Exception error)
            {
                response.Data = false;
                response.Message = error.Message;
                response.Success = false;

                return response;
            }
                       
        }  
    }    

}
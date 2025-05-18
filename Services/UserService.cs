using Microsoft.EntityFrameworkCore;
using MyTasks.Models;
using MyTasks.Interfaces;
using MyTasks.Data;

namespace MyTasks.Services
{
    public class UserService : InterfaceUserService
    {
        private readonly AppDbContext _context;


        public UserService(AppDbContext context)
        {
            _context = context;
        }

        //Retorna todos os usuarios
        public async Task<ResponseModel<IEnumerable<User>>> GetAllUsers()
        {
            ResponseModel<IEnumerable<User>> response = new();
            try
            {
                var users = await _context.User.ToListAsync();

                response.Data = users;

                if (users.Count == 0)
                {
                    response.Message = "Nenhum usuario encontrado";
                    response.Status = 404;
                    response.Success = true;

                    return response;
                }

                response.Message = "Todos os usuários foram retornados";
                response.Success = true;

                return response;


            }
            catch (Exception error)
            {
                response.Status = 500;
                response.Message = error.Message;
                response.Success = false;

                return response;
            }    
        }

        //Se o usuário existir retorna seus dados e suas "to do"
        public async Task<ResponseModel<User?>> GetUserById(int id)
        {

            ResponseModel<User?> response = new();
            try
            {
                var user = await _context.User
                .Include(u => u.Todos)
                .FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    response.Data = null;
                    response.Message = "Usuário não localizado!";
                    response.Success = false;
                    response.Status = 404;
                    return response;
                }

                response.Data = user;
                response.Message = "retornando usuario";
                response.Success = true;
                
                return response;
            }
            catch (Exception error)
            {
                response.Status = 500;
                response.Data = null;
                response.Message =error.Message;
                response.Success = false;
                
                return response;
            }
            
        }



        //Adiciona os dados do tipo User no banco, salva as alterações e retorna os dados
        public async Task<ResponseModel<User>> CreateUser(User user)
        {
            ResponseModel<User> response = new();
            try
            {
                _context.User.Add(user);
                await _context.SaveChangesAsync();
                
                response.Data = user;
                response.Message = "Usuário Cadastrado";
                response.Success = true;

                return response;
            }
            catch (Exception error)
            {
                response.Status = 500;
                response.Message = error.Message;
                response.Success = false;
                return response;
            }
            
        
        }



        public async Task<ResponseModel<User?>> UpdateUser(int id, User updated)
        {
            ResponseModel<User?> response = new();

            try
            {
                var user = await _context.User.FindAsync(id);

                if (user is null)
                {
                    response.Status = 404;
                    response.Data = null;
                    response.Message = "Nenhum usuário encontrado";
                    response.Success = false;

                    return response;
                }
                


                user.FullName = updated.FullName;
                user.Username = updated.Username;
                await _context.SaveChangesAsync();

                response.Message = "Dados atualizados";
                response.Success = true;

                return response;


            }
            catch (Exception error)
            {
                response.Status = 500;
                response.Message = error.Message;
                response.Success = false;
                return response;
            } 

            

        }




        public async Task<ResponseModel<bool>> DeleteUser(int id)
        {
            ResponseModel<bool> response = new();
            try
            {
                var user = await _context.User.FindAsync(id);
                if (user is null)
                {
                    response.Status = 404;
                    response.Data = false;
                    response.Message = "Nenhum usuario encontrado";
                    response.Success = false;

                    return response;
                }
                


                _context.User.Remove(user);
                await _context.SaveChangesAsync();

                response.Data = true;
                response.Message = "Usuário Deletado";
                response.Success = true;

                return response;
            }
            catch (Exception error)
            {
                response.Status = 500;
                response.Message = error.Message;
                response.Success = false;

                return response;
            } 
        }
    }   

}
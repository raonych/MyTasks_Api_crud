using MyTasks.Models;

namespace MyTasks.Interfaces
{
    public interface InterfaceUserService
    {   
        Task<ResponseModel<IEnumerable<User>>> GetAllUsers();
        Task<ResponseModel<User?>> GetUserById(int id);
        Task<ResponseModel<User>> CreateUser(User user);
        Task<ResponseModel<User?>> UpdateUser(int id, User user);
        Task<ResponseModel<bool>> DeleteUser(int id);
    }
} 
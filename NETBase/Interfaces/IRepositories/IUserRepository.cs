using NETBase.Models;

namespace NETBase.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserByCode(string code);
        Task<bool> CreateUser(User data);
        Task<bool> UpdateUser(User data);
        Task<bool> DeleteUser(string code);
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserByEmail(string email);
    }
}

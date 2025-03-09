using NETBase.Models;

namespace NETBase.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserByCode(string code);
        void CreateUser(User data);
        void UpdateUser(User data);
        void DeleteUser(string code);
    }
}

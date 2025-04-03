using Microsoft.EntityFrameworkCore;
using NETBase.Data;
using NETBase.DTOs;
using NETBase.Interfaces.IRepositories;
using NETBase.Models;

namespace NETBase.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataDBContext dBContext;
        public UserRepository(DataDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<bool> CreateUser(User data)
        {
            dBContext.User.Add(data);
            await dBContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(string code)
        {
            User userToDelete = await dBContext.User.FirstOrDefaultAsync(u => u.Code == code);
            if (userToDelete == null) return false;
            dBContext.Remove(userToDelete);
            await dBContext.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUserByCode(string code)
        {
            return await dBContext.User.FirstOrDefaultAsync(u => u.Code == code);
        }

        public async Task<List<User>> GetUsers()
        {
            return await dBContext.User.ToListAsync();
        }

        public async Task<bool> UpdateUser(UpdateUserDTO data)
        {
            User userToUpdate = await dBContext.User.FirstOrDefaultAsync(u => u.Code == data.Code);
            if (userToUpdate == null) return false;

            if (data.Email != null) userToUpdate.Email = data.Email;
            if (data.Username != null) userToUpdate.Username = data.Username;
            if (data.Password != null) userToUpdate.Password = data.Password;

            await dBContext.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await dBContext.User.FirstOrDefaultAsync(u => u.Username == username);
        }
        public async Task<User> GetUserByEmail(string email)
        {
            return await dBContext.User.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}

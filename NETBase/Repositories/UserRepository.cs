using Microsoft.EntityFrameworkCore;
using NETBase.Data;
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

        public async void CreateUser(User data)
        {
            dBContext.User.Add(data);
            await dBContext.SaveChangesAsync();
        }

        public async void DeleteUser(string code)
        {
            User userToDelete = await dBContext.User.FirstOrDefaultAsync(u => u.Code == code);
            if (userToDelete != null) dBContext.Remove(userToDelete);
            dBContext.SaveChanges();
        }

        public async Task<User> GetUserByCode(string code)
        {
            return await dBContext.User.FirstOrDefaultAsync(u => u.Code == code);
        }

        public async Task<List<User>> GetUsers()
        {
            return await dBContext.User.ToListAsync();
        }

        public async void UpdateUser(User data)
        {
            User userToUpdate = await dBContext.User.FirstOrDefaultAsync(u => u.Code == data.Code);
            if (userToUpdate != null) userToUpdate = data;
            dBContext.SaveChanges();
        }
    }
}

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

        public void CreateUser(User data)
        {
            dBContext.User.Add(data);
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

        public void UpdateUser(User data)
        {
            User userToUpdate = dBContext.User.FirstOrDefault();
            if (userToUpdate != null) userToUpdate = data;
            dBContext.SaveChanges();
        }
    }
}

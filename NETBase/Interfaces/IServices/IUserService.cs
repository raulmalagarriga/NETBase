using Microsoft.AspNetCore.Mvc;
using NETBase.DTOs;

namespace NETBase.Interfaces.IServices
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsers();
        Task<UserDTO> GetUserByCode(string code);
        Task<bool> CreateUser(CreateUserDTO data);
        Task<bool> UpdateUser(UpdateUserDTO data);
        Task<bool> DeleteUser(string code);
    }
}

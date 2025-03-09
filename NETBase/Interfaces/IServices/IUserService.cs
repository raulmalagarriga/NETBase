using Microsoft.AspNetCore.Mvc;
using NETBase.DTOs;

namespace NETBase.Interfaces.IServices
{
    public interface IUserService
    {
        Task<IActionResult> GetUsers();
        Task<IActionResult> GetUserByCode(string code);
        Task<IActionResult> CreateUser(UserDTO data);
        Task<IActionResult> UpdateUser(UserDTO data);
        Task<IActionResult> DeleteUser(string code);
    }
}

using Microsoft.AspNetCore.Mvc;

namespace NETBase.Interfaces.IServices
{
    public interface IUserService
    {
        Task<IActionResult> GetUsers();
        Task<IActionResult> GetUserByCode();
        Task<IActionResult> CreateUser();
        Task<IActionResult> UpdateUser();
        Task<IActionResult> DeleteUser();
    }
}

using System.ComponentModel.DataAnnotations;

namespace NETBase.DTOs
{
    public class UserDTO
    {
        public string Code { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class CreateUserDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UpdateUserDTO
    {
        public string Code { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}

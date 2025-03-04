namespace NETBase.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Code { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = System.DateTime.UtcNow;

        public User(User user)
        {
            Code = user.Code;
            Username = user.Username;
            Email = user.Email;
            Password = user.Password;
        }
    }


}

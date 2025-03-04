using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETBase.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(70)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(70)]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = System.DateTime.UtcNow;
    }


}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ImageService.Models
{
    public class User
    {
        [Key]
        [Column("id_user")]
        public int Id { get; set; }
        [Column("login_u")]
        public string? Login { get; set; }
        [Column("password_u")]
        public string? Password { get; set; }
        public ICollection<Image>? Images { get; }
        public User() { }
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}

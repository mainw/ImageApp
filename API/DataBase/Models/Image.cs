using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DataBase.Models
{
    public  class Image
    {
        [Key]
        [Column("id_image")]
        public int Id { get; set; }
        [Column("data_i")]
        public byte[]? ImageData { get; set; }
        public User? User { get; }
        public Image() { }
        public Image(User user, byte[] data)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            ImageData = data;
        }
    }
}

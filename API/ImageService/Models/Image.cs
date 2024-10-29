using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ImageService.Models
{
    public class Image
    {
        [Key]
        [Column("id_image")]
        public int IdImage { get; set; }
        [Column("id_user")]
        public int IdUser { get; set; }
        [Column("data_i")]
        public byte[] Data { get; set; }
        public User User { get; set; }
    }
}

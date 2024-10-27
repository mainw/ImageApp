using API.ImageService.DataBaseContext;
using API.ImageService.Models;
namespace API.ImageService.Repository
{
    public class ImageRepository : IImageRepository
    {
        public void Add(Image image)
        {
            Db._context.Add(image);
            Db._context.SaveChanges();
        }
        public void Delete(Image image)
        {
            Db._context.Remove(image);
            Db._context.SaveChanges();
        }
        public ICollection<Image>? GetByUser(User user)
        {
            return user.Images;
        }
    }
}

using API.ImageService.DataBaseContext;
using API.ImageService.Models;
using Microsoft.EntityFrameworkCore;
namespace API.ImageService.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly Db _context;

        public ImageRepository(Db context)
        {
            _context = context;
        }

        public void Add(Image image)
        {
            _context.Images.Add(image);
            _context.SaveChanges();
        }

        public void Delete(Image image)
        {
            _context.Images.Remove(image);
            _context.SaveChanges();
        }

        public ICollection<Image> GetByUser(User user)
        {
            return  _context.Images.Where(i => i.User.Id == user.Id).ToList();
        }
    }
}

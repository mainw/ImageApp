using API.ImageService.Models;
namespace API.ImageService.Services
{
    public interface IImageService
    {
        ICollection<Image> Get(int userId);
        void Add(int userId, byte[] imageData);
        void Delete(int userId, int imageId);
        // Другие методы
    }
}

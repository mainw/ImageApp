using API.ImageService.Models;
namespace API.ImageService.Services
{
    public interface IImageService
    {
        void Add(User user, byte[] imageData);
        void Delete(User user, Image image);
        ICollection<Image>? GetAllByUser(User user);
    }
}

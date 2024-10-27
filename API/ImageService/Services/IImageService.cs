using API.ImageService.Models;
namespace API.ImageService.Services
{
    public interface IImageService
    {
        void Add(User user, byte[] imageData);
        void Delete(Image image);
        Image? GetById(int imageId);
        User? GetUserById(int userId);
        ICollection<Image>? GetAllByUser(User user);
    }
}

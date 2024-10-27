using API.ImageService.Models;
namespace API.ImageService.Repository
{
    public interface IImageRepository
    {
        void Add(Image image);
        void Delete(Image image);
        Image? GetById(int imageId);
        ICollection<Image>? GetAllByUser(User user);
    }
}

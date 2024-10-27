using API.ImageService.Models;
namespace API.ImageService.Repository
{
    public interface IImageRepository
    {
        void Add(Image image);
        void Delete(Image image);
        ICollection<Image>? GetByUser(User user);
    }
}

using API.ImageService.Models;
namespace API.ImageService.Repository
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> GetImagesByUserIdAsync(int userId);
        Task AddImageAsync(Image image);
        Task DeleteImageAsync(int imageId);
    }
}

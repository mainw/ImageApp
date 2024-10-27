using API.ImageService.Models;
namespace API.ImageService.Services
{
    public interface IImageService
    {
        Task<IEnumerable<Image>> GetImagesAsync(int userId);
        Task AddImageAsync(int userId, byte[] imageData);
        Task DeleteImageAsync(int userId, int imageId);
        // Другие методы
    }
}

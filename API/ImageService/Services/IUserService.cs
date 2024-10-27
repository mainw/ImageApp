using API.ImageService.Models;
namespace API.ImageService.Services
{
    public interface IUserService
    {
        Task<bool> AuthenticateAsync(string username, string password);
        // Другие методы
    }
}

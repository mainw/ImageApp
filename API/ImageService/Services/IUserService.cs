using API.ImageService.Models;
namespace API.ImageService.Services
{
    public interface IUserService
    {
        bool Authenticate(string username, string password);
    }
}

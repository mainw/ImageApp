using API.ImageService.Models;
namespace API.ImageService.Services
{
    public interface IUserService
    {
        User? GetByUsernameAndPassword(string username, string password);
    }
}

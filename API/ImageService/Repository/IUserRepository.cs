using API.ImageService.Models;
namespace API.ImageService.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        //User GetUserByUsername(string username);
        ICollection<User> GetAll();
    }
}

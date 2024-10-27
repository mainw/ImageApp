using API.ImageService.Models;
namespace API.ImageService.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetById(int id);
        User? GetByUsernameAndPassword(string username, string password);
        ICollection<User> GetAll();
    }
}

using API.ImageService.Models;
namespace API.ImageService.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        ICollection<User> GetAll();
        User? GetByUsernameAndPassword(string username, string password);
        User? GetById(int id);
    }
}

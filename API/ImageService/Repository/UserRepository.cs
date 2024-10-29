using API.ImageService.DataBaseContext;
using API.ImageService.Models;

namespace API.ImageService.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Db _context;

        public UserRepository(Db context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User? GetByUsernameAndPassword(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Login == username && u.Password == password);
        }

        public ICollection<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.IdUser == id);
        }
    }
}

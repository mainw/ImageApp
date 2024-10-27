using API.ImageService.Models;
using API.ImageService.Repository;

namespace API.ImageService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        //public bool Authenticate(string username, string password)
        //{
        //    var user = _userRepository.GetByUsernameAndPassword(username, password);
        //    if (user == null)
        //    {
        //        _logger.LogInformation($"Пользователь {username} не найден");
        //        return false;
        //    }
        //    return true;
        //}
        public User? GetByUsernameAndPassword(string username, string password)
        {
            return _userRepository.GetByUsernameAndPassword(username, password);
        }
    }
}

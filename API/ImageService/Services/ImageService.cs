using API.ImageService.Models;
using API.ImageService.Repository;
namespace API.ImageService.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<ImageService> _logger;

        public ImageService(IImageRepository imageRepository, IUserRepository userRepository, ILogger<ImageService> logger)
        {
            _imageRepository = imageRepository;
            _userRepository = userRepository;
            _logger = logger;
        }
        public void Add(User user, byte[] imageData)
        {
            Image image = new Image()
            {
                User = user,
                Data = imageData
            };
            _logger.LogInformation($"______Image {user.IdUser}");
            _imageRepository.Add(image);
            _logger.LogInformation($"Добавлено изображение для пользователя ID {user.IdUser}");
        }

        public void Delete(Image image)
        {
            _imageRepository.Delete(image);
            _logger.LogInformation($"Удалено изображение ID {image.IdImage}");
        }
        public Image? GetById(int id)
        {
            return _imageRepository.GetById(id);
        }
        public User? GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }
        public ICollection<Image>? GetAllByUser(User user)
        {
            return _imageRepository.GetAllByUser(user);
        }
    }
}

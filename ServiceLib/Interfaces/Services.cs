﻿using ServiceLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLib.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);
        // Другие методы
    }

    public interface IImageRepository
    {
        Task<IEnumerable<Image>> GetImagesByUserIdAsync(int userId);
        Task AddImageAsync(Image image);
        Task DeleteImageAsync(int imageId);
        // Другие методы
    }

    public interface IUserService
    {
        Task<bool> AuthenticateAsync(string username, string password);
        // Другие методы
    }

    public interface IImageService
    {
        Task<IEnumerable<Image>> GetImagesAsync(int userId);
        Task AddImageAsync(int userId, byte[] imageData);
        Task DeleteImageAsync(int userId, int imageId);
        // Другие методы
    }
}

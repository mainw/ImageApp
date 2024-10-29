using ReactiveUI;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Net.Http.Json;
using System;
using UI.Services;
using Avalonia.Media.Imaging;
using System.IO;

namespace UI.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private readonly HttpClient _httpClient;
        private string _token;
        public ObservableCollection<ImageViewModel> Images { get; } = new ObservableCollection<ImageViewModel>();

        public MainWindowViewModel()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5000/") };
            _token = TokenService.Token;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            LoadImagesAsync();
        }

        public async Task LoadImagesAsync()
        {
            var response = await _httpClient.GetAsync("Images");
            if (response.IsSuccessStatusCode)
            {
                var images = await response.Content.ReadFromJsonAsync<List<ImageDto>>();
                Images.Clear();
                foreach (var img in images)
                {
                    Images.Add(new ImageViewModel(img));
                }
            }
        }

        public async Task AddImageAsync(string filePath)
        {
            var content = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(filePath));
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
            content.Add(fileContent, "imageFile", System.IO.Path.GetFileName(filePath));

            var response = await _httpClient.PostAsync("Images", content);
            if (response.IsSuccessStatusCode)
            {
                await LoadImagesAsync();
            }
        }

        public async Task DeleteSelectedImageAsync(int imageId)
        {
            var response = await _httpClient.DeleteAsync($"Images/{imageId}");
            if (response.IsSuccessStatusCode)
            {
                await LoadImagesAsync();
            }
        }
    }

    public class ImageViewModel : ReactiveObject
    {
        public int Id { get; }
        public string ImageData { get; }
        public Bitmap ImageBitmap
        {
            get
            {
                byte[] data = Convert.FromBase64String(ImageData);
                return new Bitmap(new MemoryStream(data));
            }
        }

        public ImageViewModel(ImageDto image)
        {
            Id = image.Id;
            ImageData = $"{image.ImageData.Trim()}";//ImageData = $"data:image/jpeg;base64,{image.ImageData.Trim()}";
        }
    }

    public class ImageDto
    {
        public int Id { get; set; }
        public string ImageData { get; set; }
    }
}
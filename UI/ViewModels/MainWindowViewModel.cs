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
using System.ComponentModel;
using System.Reactive;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private readonly HttpClient _httpClient;
        private string _token;
        private int? _selectedImageId;
        private bool _isDropEnabled;
        public ObservableCollection<ImageViewModel> Images { get; } = new ObservableCollection<ImageViewModel>();
        public ImageViewModel SelectedImage
        {
            get
            {
                if(_selectedImageId is int num && Images.Count != 0)
                    return Images[num];
                else
                    return new ImageViewModel(new ImageDto());
            }
            set
            {
                if (value is ImageViewModel)
                    this.RaiseAndSetIfChanged(ref _selectedImageId, Images.IndexOf(value));
                else
                    this.RaiseAndSetIfChanged(ref _selectedImageId, null);
                IsDropEnabled = _selectedImageId is null ? false : true;
            }
        }
        public bool IsDropEnabled
        {
            get => _isDropEnabled;
            set => this.RaiseAndSetIfChanged(ref _isDropEnabled, value);
        }

        public MainWindowViewModel()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5000/") };
            _token = TokenService.Token;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            LoadImagesAsync();
        }

        public async Task LoadImagesAsync()
        {
            _selectedImageId = null;
            var response = await _httpClient.GetAsync("Images");
            if (response.IsSuccessStatusCode)
            {
                var images = await response.Content.ReadFromJsonAsync<List<ImageDto>>();
                Images.Clear();
                foreach (var img in images)
                {
                    Console.WriteLine(img.IdImage);
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

        public async Task DeleteSelectedImageAsync(int? imageId = null)
        {
            if (imageId == null)
                imageId = Images[(int)_selectedImageId].Id;

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
            Id = image.IdImage;
            ImageData = image.ImageData;
        }
    }

    public class ImageDto
    {
        public int IdImage { get; set; }
        public string ImageData { get; set; }
    }
}
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using System;
using System.Net.Http;
using System.Reactive;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UI.Services;
namespace UI.ViewModels
{
    public class LoginViewModel : ReactiveObject
    {
        private string _username;
        private string _password;
        private readonly HttpClient _httpClient;

        public string Username
        {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        public ReactiveCommand<Unit, bool> LoginCommand { get; }

        public LoginViewModel()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5000/") };
            LoginCommand = ReactiveCommand.CreateFromTask(LoginAsync);
        }

        public async Task<bool> LoginAsync()
        {
            var request = new { Username, Password };
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("Auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var token = JsonSerializer.Deserialize<JsonElement>(responseContent).GetProperty("token").GetString();
                TokenService.Token = token;
                return true;
            }
            return false;
        }

    }
}
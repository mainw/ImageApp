using System;
using System.Text.Json;

namespace UI.Services
{
    public static class TokenService
    {
        private static string? _token;
        public static string? Token
        {
            get
            {
                return _token;
            }
            set
            {
                _token = value;
            }
        }
    }
}
using System;

namespace UI.Services
{
    public static class TokenService
    {
        private static string? _token;

        public static void SaveToken(string token)
        {
            _token = token;
        }

        public static string? GetToken()
        {
            return _token;
        }
    }
}
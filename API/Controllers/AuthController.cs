using Microsoft.AspNetCore.Mvc;
using API.ImageService.Interfaces;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IUserService userService, ILogger<AuthController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        _logger.LogInformation("Пользователь {Username} пытается авторизоваться", request.Username);
        var isAuthenticated = await _userService.AuthenticateAsync(request.Username??"", request.Password??"");
        if (isAuthenticated)
        {
            // Генерация JWT токена или другой метод авторизации
            return Ok(new { Token = "GeneratedToken" });
        }
        return Unauthorized();
    }

    // Другие действия
}

public class LoginRequest
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}
using Microsoft.AspNetCore.Mvc;
using API.ImageService.Services;

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
            return Ok();
        }
        return Unauthorized();
    }
}

public class LoginRequest
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}
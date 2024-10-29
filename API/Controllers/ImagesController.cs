using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.ImageService.Services;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Serilog;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ImagesController : ControllerBase
{
    private readonly IImageService _imageService;
    private readonly ILogger<ImagesController> _logger;

    public ImagesController(IImageService imageService, ILogger<ImagesController> logger)
    {
        _imageService = imageService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetImages()
    {
        var userId = GetUserId();
        Log.Information($"Пользователь: {_imageService.GetUserById(userId).Login} {_imageService.GetAllByUser(_imageService.GetUserById(userId)).Count}");
        var images = _imageService.GetAllByUser(_imageService.GetUserById(userId));
        return Ok(images?.Select(i => new { i.IdImage, ImageData = Convert.ToBase64String(i.Data) }));
    }

    [HttpPost]
    public IActionResult AddImage(IFormFile imageFile)
    {
        var userId = GetUserId();
        using var memoryStream = new MemoryStream();
        imageFile.CopyToAsync(memoryStream);
        _imageService.Add(_imageService.GetUserById(userId), memoryStream.ToArray());
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteImage(int id)
    {
        _imageService.Delete(_imageService.GetById(id));
        return Ok();
    }

    private int GetUserId()
    {
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
        return userIdClaim != null ? int.Parse(userIdClaim.Value) : throw new Exception("User ID not found in token");
    }
}
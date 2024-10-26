using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLib.Interfaces;

[ApiController]
[Route("api/[controller]")]
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
    public async Task<IActionResult> GetImages()
    {
        var userId = GetUserId(); // Реализуйте метод получения ID из токена
        var images = await _imageService.GetImagesAsync(userId);
        return Ok(images);
    }

    [HttpPost]
    public async Task<IActionResult> AddImage([FromForm] IFormFile imageFile)
    {
        var userId = GetUserId();
        using var memoryStream = new MemoryStream();
        await imageFile.CopyToAsync(memoryStream);
        await _imageService.AddImageAsync(userId, memoryStream.ToArray());
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteImage(int id)
    {
        var userId = GetUserId();
        await _imageService.DeleteImageAsync(userId, id);
        return NoContent();
    }

    private int GetUserId()
    {
        // Реализуйте получение ID пользователя из Claims
        return 1; // Пример
    }
}
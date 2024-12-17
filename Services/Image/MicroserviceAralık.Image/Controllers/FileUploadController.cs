using MicroserviceAralık.Image.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralık.Image.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FileUploadController(IFileUploader _fileUploader) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        var result = await _fileUploader.UploadFile(file);
        return Ok(result);
    }
}

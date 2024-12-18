using MicroserviceAralık.Image.Context;
using MicroserviceAralık.Image.Dtos.BrandImageDtos;
using MicroserviceAralık.Image.Entities;
using MicroserviceAralık.Image.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralık.Image.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BrandImagesController(IFileUploader _fileUploader, ImageContext _imageContext) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> UploadBrandImage(CreateBrandImageDto dto)
    {
        var uploadFile = await _fileUploader.UploadFile(dto.ImageFile);
        if (uploadFile != null)
        {
            var brandImage = new BrandImage
            {
                ImageUrl = uploadFile,
                BrandId = dto.BrandId
            };
            await _imageContext.AddAsync(brandImage);
            await _imageContext.SaveChangesAsync();
            return Ok("Image created successfully");
        }
        return BadRequest("Image couldn't upload!");
    }
    [HttpGet]
    public async Task<IActionResult> GetAllBrandImages()
    {
        return Ok(await _imageContext.BrandImages.ToListAsync());
    }
    [HttpGet("GetBrandImageById")]
    public async Task<IActionResult> GetBrandImageById(string productId)
    {
        return Ok(await _imageContext.BrandImages.Where(x => x.BrandId == productId).ToListAsync());
    }
}
using MicroserviceAralık.Image.Context;
using MicroserviceAralık.Image.Dtos.ProductImageDtos;
using MicroserviceAralık.Image.Entities;
using MicroserviceAralık.Image.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralık.Image.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductImagesController(IFileUploader _fileUploader, ImageContext _imageContext) : ControllerBase
{
    [Authorize(Policy = "ImageFullAccess")]
    [HttpPost]
    public async Task<IActionResult> UploadProductImage(CreateProductImageDto dto)
    {
        var uploadFile = await _fileUploader.UploadFile(dto.ImageFile);
        if (uploadFile != null)
        {
            var productImage = new ProductImage
            {
                ImageUrl = uploadFile,
                ProductId = dto.ProductId
            };
            await _imageContext.AddAsync(productImage);
            await _imageContext.SaveChangesAsync();
            return Ok("Image created successfully");
        }
        return BadRequest("Image couldn't upload!");
    }
    [Authorize(Policy = "ImageReadAccess")]
    [HttpGet]
    public async Task<IActionResult> GetAllProductImages()
    {
        return Ok(await _imageContext.ProductImages.ToListAsync());
    }
    [Authorize(Policy = "ImageReadAccess")]
    [HttpGet("GetProductImageById")]
    public async Task<IActionResult> GetProductImageById(string productId)
    {
        return Ok(await _imageContext.ProductImages.Where(x => x.ProductId == productId).ToListAsync());
    }
}

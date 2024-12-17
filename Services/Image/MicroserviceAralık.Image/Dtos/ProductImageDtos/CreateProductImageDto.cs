namespace MicroserviceAralık.Image.Dtos.ProductImageDtos;

public class CreateProductImageDto
{
    public IFormFile ImageFile { get; set; }
    public string ProductId { get; set; }
}

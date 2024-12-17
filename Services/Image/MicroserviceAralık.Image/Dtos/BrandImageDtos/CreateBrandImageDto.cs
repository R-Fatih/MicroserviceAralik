namespace MicroserviceAralık.Image.Dtos.BrandImageDtos;

public class CreateBrandImageDto
{
    public IFormFile ImageFile { get; set; }
    public string BrandId { get; set; }
}

namespace MicroserviceAralık.Image.Services;

public interface IFileUploader
{
    Task<string> UploadFile(IFormFile formFile);
}

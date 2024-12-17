using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using MicroserviceAralık.Image.Settings;

namespace MicroserviceAralık.Image.Services;

public class FileUploader(IConfiguration _configuration) : IFileUploader
{
    public async Task<string> UploadFile(IFormFile formFile)
    {

        var awsSettings = _configuration.GetSection("AWSSettings").Get<AWSSettings>();
        var s3Config = new AmazonS3Config
        {
            ForcePathStyle = true,
            ServiceURL = awsSettings.ServiceUrl
        };
        var s3Client = new AmazonS3Client(awsSettings.AccessKeyId, awsSettings.SecretAccessKey, s3Config);
        var tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName));
        using (var stream = new FileStream(tempFilePath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
        }
        var putRequest = new PutObjectRequest
        {
            BucketName = awsSettings.BucketName,
            Key = Path.GetFileName(tempFilePath),
            FilePath = tempFilePath,
            AutoCloseStream = true,
            DisablePayloadSigning = true,
            StreamTransferProgress = new EventHandler<StreamTransferProgressArgs>((sender, args) =>
            {
                Console.WriteLine($"Progress: {args.PercentDone}, Transferred:  {args.TransferredBytes}, Total: {args.TotalBytes}");
            })
        };
        try
        {
            var response = await s3Client.PutObjectAsync(putRequest);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                return $"{awsSettings.Domain}/{putRequest.Key}";

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

        }
        return null;
    }
}

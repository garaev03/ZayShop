namespace Zay.Business.Services.Interfaces
{
    public interface IImageService
    {
        void CheckImageType(IFormFile formFile);
        void CheckSize(IFormFile formFile);
        Task<string> CreateImageAsync(string Rootpath, string FolderPath, IFormFile formFile);
    }
}

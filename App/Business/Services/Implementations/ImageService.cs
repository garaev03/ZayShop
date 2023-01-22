using Microsoft.AspNetCore.Http;
using Zay.Business.Services.Interfaces;

namespace Zay.Business.Services.Implementations
{
    public class ImageService : IImageService
    {
        public void CheckImageType(IFormFile formFile)
        {
            if (!formFile.ContentType.Contains("image"))
                throw new Exception("file is not image!");
        }

        public void CheckSize(IFormFile formFile)
        {
            if (formFile.Length / 1024 / 1024 >= 2)
                throw new Exception("file size is bigger than 2MB!");
        }

        public async Task<string> CreateImageAsync(string Rootpath, string FolderPath, IFormFile formFile)
        {
            string newFileName = Guid.NewGuid() + "-" + formFile.FileName;
            string Fullpath = Rootpath + "/" + FolderPath + newFileName;
            using (FileStream reader = new(Fullpath, FileMode.Create))
            {
                await formFile.CopyToAsync(reader);
            }
            return newFileName;
        }
    }
}

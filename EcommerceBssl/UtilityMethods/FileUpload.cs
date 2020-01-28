using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceBssl.UtilityMethods
{
    public static class FileUpload
    {
       public static async Task<string> UploadFile(IFormFile formFile, string folderName)
        {
            var fileName = DateTime.Now.Ticks.ToString() + formFile.FileName;

            var filepath = Path.Combine(Directory.GetCurrentDirectory(), $@"wwwroot\{folderName}", fileName);

            await formFile.CopyToAsync(new FileStream(filepath, FileMode.Create));

            return $"{folderName}\\{fileName}";
        }
    }
}

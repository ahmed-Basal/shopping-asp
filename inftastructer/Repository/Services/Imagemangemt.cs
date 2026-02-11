using core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Text;

namespace inftastructer.Repository.Services
{
    public class Imagemangemt : IIamgeServices
    {
        private readonly IFileProvider _fileProvider;
        public Imagemangemt(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }
        public async Task<List<string>> AddImageAsync(IFormFileCollection files, string src)
        {
            List<string> SaveImageSrc = new List<string>();

            var ImageDirctory = Path.Combine("wwwroot", "Images", src);

            if (!Directory.Exists(ImageDirctory))
            {
                Directory.CreateDirectory(ImageDirctory);
            }

            foreach (var item in files)
            {
                if (item.Length > 0)
                {
                    var ImageName = item.FileName;

                    var ImageSrc = $"/Images/{src}/{ImageName}";
                    var root = Path.Combine(ImageDirctory, ImageName);

                    using var stream = new FileStream(root, FileMode.Create);
                    await item.CopyToAsync(stream);

                    SaveImageSrc.Add(ImageSrc);
                }
            }

            return SaveImageSrc; 
}


        public void DeleteImageAsync(string src)
        {
            var info = _fileProvider.GetFileInfo(src);

            var root = info.PhysicalPath;
            File.Delete(root);
        }




    }
}

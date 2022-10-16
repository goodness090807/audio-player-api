using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ExternalServices.Cloudinary
{
    public class CloudinaryService :ICloudinaryService
    {
        private readonly CloudinaryDotNet.Cloudinary _cloudinary;
        private readonly string _audioFolderName = "audios";

        public CloudinaryService(CloudinaryDotNet.Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }

        public async Task<VideoUploadResult> UploadAudioAsync(IFormFile audioFile)
        {
            using var stream = audioFile.OpenReadStream();
            var extension = Path.GetExtension(audioFile.FileName);

            var uploadParams = new VideoUploadParams()
            {
                File = new CloudinaryDotNet.FileDescription($"{Guid.NewGuid()}{extension}", stream),
                Folder = _audioFolderName
            };

            return await _cloudinary.UploadAsync(uploadParams);
        }
    }
}

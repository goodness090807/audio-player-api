using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ExternalServices.Cloudinary
{
    public interface ICloudinaryService
    {
        Task<VideoUploadResult> UploadAudioAsync(IFormFile audioFile);
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services.Audio.Models.Params
{
    public class UploadAudioParam
    {
        public IFormFile MyProperty { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace audio_play_api.Controllers.Audio.Models.Params
{
    public class UploadAudioParam
    {
        public class Form
        {
            [Required]
            public IFormFile AudioFile { get; set; }
        }
    }
}

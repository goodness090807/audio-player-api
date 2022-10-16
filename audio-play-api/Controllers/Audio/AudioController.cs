using audio_play_api.Controllers.Audio.Models.Dtos;
using audio_play_api.Controllers.Audio.Models.Params;
using BussinessLayer.ExternalServices.Cloudinary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace audio_play_api.Controllers.Audio
{
    public class AudioController : BaseController
    {
        private readonly ICloudinaryService _cloudinaryService;

        public AudioController(ICloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AudioListDto>>> GetAudioListAsync()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> UploadAudioAsync([FromForm] UploadAudioParam.Form formParam)
        {
            var result = await _cloudinaryService.UploadAudioAsync(formParam.AudioFile);
            return Ok(result);
        }

    }
}

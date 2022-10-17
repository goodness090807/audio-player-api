using audio_player_api.Controllers.Audio.Models.Dtos;
using audio_player_api.Controllers.Audio.Models.Params;
using BussinessLayer.ExternalServices.Cloudinary;
using BussinessLayer.Services.Audio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace audio_player_api.Controllers.Audio
{
    public class AudioController : BaseController
    {
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IAudioService _audioService;

        public AudioController(ICloudinaryService cloudinaryService, IAudioService audioService)
        {
            _cloudinaryService = cloudinaryService;
            _audioService = audioService;
        }

        [HttpGet]
        public async Task<IEnumerable<GetAudiosDto>> GetAudiosAsync()
        {
            return (await _audioService.GetAudiosAsync()).Select(x => new GetAudiosDto
            {
                Id = x.id,
                Name = x.name,
                Url = x.url
            });
        }

        [HttpPost]
        public async Task<ActionResult> UploadAudioAsync([FromForm] UploadAudioParam.Form formParam)
        {
            var result = await _cloudinaryService.UploadAudioAsync(formParam.AudioFile);
            return Ok(result);
        }

    }
}

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
    public class AudiosController : BaseController
    {
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IAudioService _audioService;

        public AudiosController(ICloudinaryService cloudinaryService, IAudioService audioService)
        {
            _cloudinaryService = cloudinaryService;
            _audioService = audioService;
        }

        [HttpGet]
        public async Task<IEnumerable<GetAudiosDto>> GetAudiosAsync([FromQuery] GetAudiosParam getAudiosParam)
        {
            return (await _audioService.GetAudiosAsync(getAudiosParam.Page, getAudiosParam.PageSize)).Select(x => new GetAudiosDto
            {
                Id = x.id,
                Name = x.name,
                Description = x.description,
                AudioUrl = x.audioUrl,
                ImageUrl = x.imageUrl
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

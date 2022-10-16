using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace audio_play_api.Controllers.Audio.Models.Dtos
{
    public class AudioListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace audio_play_api
{
    public class AppSettings
    {
        public CloudinarySettingsDto CloudinarySettings { get; set; }

        public class CloudinarySettingsDto
        {
            public string CloudName { get; set; }
            public string APIKey { get; set; }
            public string APISecret { get; set; }
        }
    }
}

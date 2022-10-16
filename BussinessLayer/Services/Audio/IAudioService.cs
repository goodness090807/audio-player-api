using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services.Audio
{
    public interface IAudioService
    {
        Task<bool> InsertAudioAsync();
    }
}

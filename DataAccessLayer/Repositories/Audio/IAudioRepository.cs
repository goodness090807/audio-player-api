using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Audio
{
    public interface IAudioRepository
    {
        Task AddAudioAsync();
    }
}

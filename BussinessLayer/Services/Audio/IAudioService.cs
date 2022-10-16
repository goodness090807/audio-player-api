using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLayer.Services.Audio
{
    public interface IAudioService
    {
        Task<IEnumerable<(int id, string name, string url)>> GetAudiosAsync();
    }
}

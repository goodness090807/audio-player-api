using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Audio
{
    public interface IAudioRepository
    {
        Task<IEnumerable<(int id, string name, string url)>> GetAudiosAsync();
        Task<IEnumerable<(int id, string name, string url)>> GetUserAudiosAsync(int userId);
        Task AddAudioAsync();
    }
}

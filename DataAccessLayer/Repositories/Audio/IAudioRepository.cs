using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Audio
{
    public interface IAudioRepository
    {
        Task<IEnumerable<(int id, string name, string description, string audioUrl, string imageUrl)>> GetAudiosAsync((int offset, int limit) pagination);
        Task<IEnumerable<(int id, string name, string url)>> GetUserAudiosAsync(int userId);
        Task AddAudioAsync();
    }
}

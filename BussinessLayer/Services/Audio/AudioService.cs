using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Repositories.Audio;
using DataAccessLayer.UnitOfWorks;

namespace BussinessLayer.Services.Audio
{
    public class AudioService : IAudioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAudioRepository _audioRepository;

        public AudioService(IUnitOfWork unitOfWork, IAudioRepository audioRepository)
        {
            _unitOfWork = unitOfWork;
            _audioRepository = audioRepository;
        }
        
        public async Task<IEnumerable<(int id, string name, string url)>> GetAudiosAsync()
        {
            return await _audioRepository.GetAudiosAsync();
        }
    }
}

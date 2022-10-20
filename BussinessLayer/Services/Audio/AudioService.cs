using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Repositories.Audio;
using DataAccessLayer.UnitOfWorks;
using DataAccessLayer.Utils;

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
        
        public async Task<IEnumerable<(int id, string name, string description, string audioUrl, string imageUrl)>> GetAudiosAsync(int page, int pageSize)
        {
            return await _audioRepository.GetAudiosAsync(PaginationHelper.GetOffsetAndLimit(page, pageSize));
        }
    }
}

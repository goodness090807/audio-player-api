using DataAccessLayer.UnitOfWorks;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Audio
{
    public class AudioRepository : IAudioRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public AudioRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddAudioAsync()
        {
            throw new NotImplementedException();
        }
    }
}

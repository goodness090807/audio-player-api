using DataAccessLayer.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace DataAccessLayer.Repositories.Audio
{
    public class AudioRepository : IAudioRepository
    {
        private readonly DbSession _dbSession;

        public AudioRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<IEnumerable<(int id, string name, string url)>> GetAudiosAsync()
        {
            var strSQL = @"
                SELECT id, name, url FROM `audio_service`.`user_audios`";

            return await _dbSession.Connection.QueryAsync<(int id, string name, string url)>(strSQL);
        }

        public async Task<IEnumerable<(int id, string name, string url)>> GetUserAudiosAsync(int userId)
        {
            var strSQL = @"
                SELECT
                    id, name, url
                FROM
                    `audio_service`.`user_audios`";

            return await _dbSession.Connection.QueryAsync<(int id, string name, string url)>(strSQL, new { UserId = userId});
        }

        public Task AddAudioAsync()
        {
            throw new NotImplementedException();
        }
    }
}

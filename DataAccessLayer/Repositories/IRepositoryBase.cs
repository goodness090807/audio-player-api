using System.Data;

namespace DataAccessLayer.Repositories
{
    public interface IRepositoryBase
    {
        IDbConnection Connection { get; set; }
        IDbTransaction Transaction { get; set; }
    }
}

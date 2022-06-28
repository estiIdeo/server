
using Health.Data;
using Ideo.NetCore.Data.UnitOfWork.Core.Interfaces;

namespace Health.DataAccessLayer
{
    public interface IUnitOfWork : IUnitOfWork<HealthDbContext>
    {
    }
}

using Health.Data;
using Ideo.NetCore.Data.UnitOfWork.Services;

namespace Health.DataAccessLayer
{
    internal class UnitOfWork : UnitOfWork<HealthDbContext>, IUnitOfWork
    {
        public UnitOfWork(HealthDbContext dbContext, IServiceProvider serviceProvider) : base(dbContext, serviceProvider)
        {
        }
    }
}

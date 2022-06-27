using Health.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

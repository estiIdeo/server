
using Health.Data;
using Ideo.NetCore.Data.UnitOfWork.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.DataAccessLayer
{
    public interface IUnitOfWork : IUnitOfWork<HealthDbContext>
    {
    }
}

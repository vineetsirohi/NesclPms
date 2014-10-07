using NesclPms.Domain.Concrete;
using NesclPms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesclPms.Domain.Abstract
{
    public interface IEntitiesRepository
    {
        EFDbContext Context { get; }
        IEnumerable<VehicleBill> VehicleBills { get; }
    }
}

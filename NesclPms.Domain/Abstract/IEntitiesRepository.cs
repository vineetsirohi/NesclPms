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
        IEnumerable<VehicleBill> VehicleBills { get; }
    }
}

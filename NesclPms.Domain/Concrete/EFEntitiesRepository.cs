using NesclPms.Domain.Abstract;
using NesclPms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesclPms.Domain.Concrete
{
    public class EFEntitiesRepository : IEntitiesRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<VehicleBill> VehicleBills
        {
            get { return context.VehicleBills; }
        }
    }
}

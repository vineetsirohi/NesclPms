using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesclPms.Domain.Entities
{
    public class VehicleBill
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public long Date { get; set; }
        public string Comments { get; set; }

    }
}

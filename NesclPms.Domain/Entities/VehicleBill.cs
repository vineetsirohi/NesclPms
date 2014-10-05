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
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Comments { get; set; }
        public bool IsPrepared { get; set; }
        public bool IsVerified { get; set; }
        public bool IsPassed { get; set; }
    }
}

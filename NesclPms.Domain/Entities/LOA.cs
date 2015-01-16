using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NesclPms.Domain.Entities
{
    class LOA
    {
        public int Id { get; set; }
        public string No { get; set; }
        public string Description { get; set; }
        public Agency Agency { get; set; }
        public DateTime Date { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NesclPms.Domain.Entities
{
    public class LOA
    {
        public int Id { get; set; }
        public string No { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public virtual Agency Agency { get; set; }
        public virtual IEnumerable<LoaDetail> Components { get; set; }
        public virtual IEnumerable<LoaAmendment> LoaAmendments { get; set; }
    }
}

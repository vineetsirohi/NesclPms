using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesclPms.Domain.Entities
{
    public class LoaAmendment
    {
        public int Id { get; set; }
        public int LoaId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public virtual IEnumerable<LoaDetail> LoaDetails { get; set; }
    }
}

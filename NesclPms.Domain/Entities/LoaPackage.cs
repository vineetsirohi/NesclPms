using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NesclPms.Domain.Entities
{
    public class LoaPackage
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required]
        [StringLength(1024)]
        public string No { get; set; }

        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        public int AgencyId { get; set; }

        public virtual Agency Agency { get; set; }
    }
}
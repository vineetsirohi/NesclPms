using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesclPms.Domain.Entities
{
    public class LoaPriceComponent
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required]
        public int LoaPackageId { get; set; }

        [Required]
        [StringLength(1024)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesclPms.Domain.Entities
{
    public class LoaAmendment
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required]
        public int LoaPackageId { get; set; }

        [Required]
        [StringLength(1024)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public virtual LoaPackage LoaPackage { get; set; }
    }
}

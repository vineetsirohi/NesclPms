using System.ComponentModel.DataAnnotations;

namespace NesclPms.Domain.Entities
{
    public class Agency
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(1024)]
        public string AddressLine1 { get; set; }

        [StringLength(1024)]
        public string AddressLine2 { get; set; }

        [Required]
        [StringLength(160)]
        public string City { get; set; }

        [Required]
        [StringLength(160)]
        public string State { get; set; }

        [Required]
        [StringLength(160)]
        public string Country { get; set; }

        [StringLength(160)]
        public string Pin { get; set; }

//        Other data annotations
//        [DisplayName("Album Art URL")]
//         [Required(ErrorMessage = "An Album Title is required")]
//        [Range(0.01, 100.00, ErrorMessage = "Price must be between 0.01 and 100.00")]
    }
}
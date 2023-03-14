using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlateformService.Models
{
    public class Plateform
    {
        [Key]
        [Column("IdPlateform")]
        public int Id { get; set; }

        [Required]
        [StringLength(20), MinLength(3)]
        public String? Name { get; set; }

        [Required]
        [StringLength(20), MinLength(3)]
        public String? Publisher { get; set; }

        [Required]
        [StringLength(20), MinLength(3)]
        public String? Cost { get; set; }
    }
}

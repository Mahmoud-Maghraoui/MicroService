using System.ComponentModel.DataAnnotations;

namespace PlateformService.Dtos
{
    public class PlateformCreateDto
    {
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class PerfumeDto:BaseDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string FragranceCategory { get; set; }

        [Required]
        public decimal Price { get; set; }

        //Navigation property
        public int BrandID { get; set; }
        public BrandDto Brand { get; set; }
    }
}

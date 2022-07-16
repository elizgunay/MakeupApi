using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class ProductDto:BaseDto
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Code { get; set; }
        //public bool isStock { get; set; }

        [Required]
        public decimal Price { get; set; }


        public int currentPageIndex { get; set; }
        public int pageCount { get; set; }

        //Navigation property
        public int BrandID { get; set; }
        public BrandDto Brand { get; set; }

        public int CategoryID { get; set; }
        public CategoryDto Category { get; set; }
    }
}

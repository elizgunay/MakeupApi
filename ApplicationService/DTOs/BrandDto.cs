using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
   public class BrandDto:BaseDto
    {
        [Required]
        public string BrandName { get; set; }

       // public BrandDto() { }


        public bool Validate()
        {
            return !String.IsNullOrEmpty(BrandName);
        }
    }
}

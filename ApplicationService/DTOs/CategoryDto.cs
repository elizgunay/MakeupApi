using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class CategoryDto:BaseDto
    {
        [Required]
        public string CategoryName { get; set; }
    }
}

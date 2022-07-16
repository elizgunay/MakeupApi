using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Data.Entities
{
    public class Product:BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        [StringLength(300)]
        public string Description { get; set; }
       
        public string Code { get; set; }
       // public bool isStock { get; set; }
      
        public decimal Price { get; set; }


        [DisplayName("Upload File")]
        public string Image { get; set; }

        //public IFormFile ImageFiles { get; set; }

        //Navigation property
        
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

      
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

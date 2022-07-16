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
    public class Perfume:BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        [StringLength(300)]
        public string Description { get; set; }
        public string Gender { get; set; }
        public string FragranceCategory { get; set; }
        public decimal Price { get; set; }

       // [DisplayName("Upload Image")]
        public string Image { get; set; }
        //public IFormFile Image { get; set; }

        //Relationship
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
}

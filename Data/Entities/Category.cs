using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Category:BaseEntity
    {
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(20)]
        public string CategoryName { get; set; }

        //Nav property
        public virtual ICollection<Product> Products { get; set; }
    }
}

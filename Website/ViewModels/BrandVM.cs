using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.ViewModels
{
    public class BrandVM
    {
        public int Id { get; set; }

        [Required]
        public string BrandName { get; set; }

        //public virtual ICollection<ProductVM> product { get; set; }

        public BrandVM() { }

        public BrandVM(BrandDto brandDto)
        {
            Id = brandDto.Id;
            BrandName = brandDto.BrandName;
        }
    }
}
using ApplicationService.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public string Code { get; set; }
        //public bool isStock { get; set; }
        [Required]
        public decimal Price { get; set; }

        [DisplayName("Upload File")]
        public HttpPostedFileBase Image { get; set; }

       // public HttpPostedFileBase file { get; set; }
       // public HttpPostedFileBase ImageFile { get; set; }

        public int currentPageIndex { get; set; }
        public int pageCount { get; set; }

        //Navigation property
        [Required]
        public int BrandID { get; set; }
        public virtual BrandVM Brand { get; set; }

        [Required]
        public int CategoryID { get; set; }
        public virtual CategoryVM Category { get; set; }

        public ProductVM() { }

        public ProductVM(ProductDto productDto)
        {
            Id = productDto.Id;
            ProductName = productDto.ProductName;
            Description = productDto.Description;
            Code = productDto.Code;
            Price = productDto.Price;
            BrandID = productDto.Brand.Id;
            CategoryID = productDto.Category.Id;

            Brand = new BrandVM
            {
                Id = productDto.Brand.Id,
                BrandName = productDto.Brand.BrandName
            };

            Category = new CategoryVM
            {
                Id = productDto.Category.Id,
                CategoryName = productDto.Category.CategoryName
            };
        }
    }
}
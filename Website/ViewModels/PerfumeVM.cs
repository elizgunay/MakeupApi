using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.ViewModels
{
    public class PerfumeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public string FragranceCategory { get; set; }
        public decimal Price { get; set; }

        //Navigation property
        public int BrandID { get; set; }
        public BrandVM Brand { get; set; }

        
        public PerfumeVM() { }

        public PerfumeVM(PerfumeDto perfumeDto)
        {
            Id = perfumeDto.Id;
            Name = perfumeDto.Name;
            Description = perfumeDto.Description;
            Gender = perfumeDto.Gender;
            Price = perfumeDto.Price;
            BrandID = perfumeDto.Brand.Id;

            Brand = new BrandVM
            {
                Id = perfumeDto.Brand.Id,
                BrandName = perfumeDto.Brand.BrandName
            };

           
        }
    }
}
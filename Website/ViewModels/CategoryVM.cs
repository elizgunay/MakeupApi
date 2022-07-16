using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public CategoryVM() { }

        public CategoryVM(CategoryDto categoryDto)
        {
            Id = categoryDto.Id;
            CategoryName = categoryDto.CategoryName;
        }
    }
}
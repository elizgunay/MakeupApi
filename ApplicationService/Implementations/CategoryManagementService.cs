using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class CategoryManagementService
    {
        MakeupApiContext db = new MakeupApiContext();

        public List<CategoryDto> GetAll()
        {
            List<CategoryDto> categoriesDto = null;
            using (var x = new MakeupApiContext())
            {
                categoriesDto = x.Categories
                    .Select(c => new CategoryDto()
                    {
                        Id = c.Id,
                        CategoryName = c.CategoryName

                    })/*.Where(v => v.CategoryName.StartsWith(search) || search == null)*/
                    .ToList<CategoryDto>();

            }
            return categoriesDto;
        }

        public CategoryDto GetById(int id)
        {
            CategoryDto categoryDto = new CategoryDto();

            using (var x = new MakeupApiContext())
            {
                categoryDto = x.Categories
                    .Where(i => i.Id == id)
                    .Select(c => new CategoryDto()
                    {
                        Id = c.Id,
                        CategoryName = c.CategoryName
                    }).FirstOrDefault();
            }
            return categoryDto;
        }

        public CategoryDto Save(CategoryDto categoryDto)
        {
            using (var x = new MakeupApiContext())
            {
                x.Categories.Add(new Category()
                {
                    CategoryName = categoryDto.CategoryName
                });
                x.SaveChanges();
            }
            return categoryDto;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;

            try
            {

                Category category = db.Categories.Find(id);
                db.Categories.Remove(category);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

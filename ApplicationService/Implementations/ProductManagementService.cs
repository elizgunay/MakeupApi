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
    public class ProductManagementService
    {
        MakeupApiContext db = new MakeupApiContext();
      //  int page_size = 3;
        public List<ProductDto> GetAll()
        {
            List<ProductDto> productsDto = null;
            using (var x = new MakeupApiContext())
            {

                //int maxRowsPerPage = 5;

                productsDto = x.Products
                    .Select(c => new ProductDto()
                    {
                        Id = c.Id,
                        ProductName = c.ProductName,
                        Description = c.Description,
                        Code = c.Code,
                        Price = c.Price,
                        BrandID = c.BrandId,
                        CategoryID = c.CategoryId,

                    })

                //    .Skip(page*page_size)
                //    .Take(page_size)
                   .ToList<ProductDto>();

                //int totalProduct = productsDto.Count();

                //double pageCount = (float)(totalProduct / maxRowsPerPage);

                // pageCount = (int)Math.Ceiling(pageCount);


                //productsDto = x.Products.OrderBy(a => a.Name)
                //.Skip(page * page_size)
                //.Take(page_size);

            }
            return productsDto;
        }

        public ProductDto GetById(int id)
        {
            ProductDto productDto = new ProductDto();


            using (var x = new MakeupApiContext())
            {
                productDto = x.Products
                    .Where(i => i.Id == id)
                    .Select(c => new ProductDto()
                    {
                        Id = c.Id,
                        ProductName = c.ProductName,
                        Description = c.Description,
                        Code = c.Code,
                        Price = c.Price,
                        BrandID = c.BrandId,
                        CategoryID = c.CategoryId

                    }).FirstOrDefault();
            }
            return productDto;
        }

        public ProductDto Save(ProductDto productDto)
        {
            using (var x = new MakeupApiContext())
            {
                x.Products.Add(new Product()
                {
                    ProductName = productDto.ProductName,
                    Description = productDto.Description,
                    Code = productDto.Code,
                    Price = productDto.Price,
                    BrandId = productDto.BrandID,
                    CategoryId = productDto.CategoryID

                });
                x.SaveChanges();
            }
            return productDto;
        }


        public bool Delete(int id)
        {
            if (id == 0) return false;

            try
            {
                Product product = db.Products.Find(id);
                db.Products.Remove(product);
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

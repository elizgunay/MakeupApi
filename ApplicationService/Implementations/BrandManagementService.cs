using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApplicationService.Implementations
{
    public class BrandManagementService
    {
        MakeupApiContext db = new MakeupApiContext();

        public List<BrandDto> GetAll(/*string search*/)
        {


            //{
            //    if (page > 0)
            //    {
            //        page = page;
            //    }
            //    else
            //    {
            //        page = 1;
            //    }

            //    int limit = 3;
            //    int start = (int)(page - 1) * limit;

            //    var data = db.Brands
            //        .OrderBy(e => e.Id)
            //        .Skip(start)
            //        .Take(limit);

            //    int totalProduct = data.Count();
            //    float numberPage = (float)totalProduct / limit;


            //    return (data.Select(e => new BrandDto
            //    {
            //        Id = e.Id,
            //        BrandName = e.BrandName

            //    })).Where(v => v.BrandName.StartsWith(search) || search == null).ToList();
            ////////////////////////////////////////////////////////////////////////////////////////
            List<BrandDto> brandsDto = null;
            using (var x = new MakeupApiContext())
            {
                brandsDto = x.Brands
                    .Select(c => new BrandDto()
                    {
                        Id = c.Id,
                        BrandName = c.BrandName

                    })/*.Where(v => v.BrandName.StartsWith(search) || search == null)*/
                    .ToList<BrandDto>();



            }
            return brandsDto;

        }

        //List<BrandDto> brandsDto = new List<BrandDto>();

        //foreach (var item in db.Brands.ToList())
        //{
        //    brandsDto.Add(new BrandDto
        //    {
        //        Id = item.Id,
        //        BrandName = item.BrandName
        //    });
        //}
        //return brandsDto;


        public BrandDto GetById(int id)
        {
            BrandDto brandDto = new BrandDto();

            //Brand brand = db.Brands.Find(id);
            //if (brand != null)
            //{
            //    brandDto.Id = brand.Id;
            //    brandDto.BrandName = brand.BrandName;
            //}

            using (var x = new MakeupApiContext())
            {
                brandDto = x.Brands
                    .Where(i => i.Id == id)
                    .Select(c => new BrandDto()
                    {
                        Id = c.Id,
                        BrandName = c.BrandName
                    }).FirstOrDefault();
            }
            return brandDto;
        }

        public BrandDto Save(BrandDto brandDto)
        {
            using (var x = new MakeupApiContext())
            {
                x.Brands.Add(new Brand()
                {
                    BrandName = brandDto.BrandName
                });
                x.SaveChanges();
            }
            return brandDto;


            //Brand brand = new Brand()
            //{
            //    Id = brandDto.Id,
            //    BrandName = brandDto.BrandName
            //};

            //try
            //{
            //    //db.Brands.Add(brand);
            //    //db.SaveChanges();

            //    using (UnitOfWork unitOfWork = new UnitOfWork())
            //    {
            //        if (brandDto.Id == 0)
            //            unitOfWork.BrandRepository.Insert(brand);
            //        else
            //            unitOfWork.BrandRepository.Update(brand);
            //        unitOfWork.Save();
            //    }

            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}

        }


        public bool Delete(int id)
        {
            if (id == 0) return false;

            try
            {

                Brand brand = db.Brands.Find(id);
                db.Brands.Remove(brand);
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

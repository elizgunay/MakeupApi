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
    public class PerfumeManagementService
    {
        MakeupApiContext db = new MakeupApiContext();
        
        public List<PerfumeDto> GetAll()
        {
            List<PerfumeDto> perfumeDto = null;
            using (var x = new MakeupApiContext())
            {
                perfumeDto = x.Perfumes
                    .Select(c => new PerfumeDto()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        Gender = c.Gender,
                        FragranceCategory = c.FragranceCategory,
                        Price = c.Price,
                        BrandID = c.BrandId,
                       

                    }).ToList<PerfumeDto>();


            }
            return perfumeDto;
        }

        public PerfumeDto GetById(int id)
        {
            PerfumeDto perfumeDto = new PerfumeDto();


            using (var x = new MakeupApiContext())
            {
                perfumeDto = x.Perfumes
                    .Where(i => i.Id == id)
                    .Select(c => new PerfumeDto()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        Gender = c.Gender,
                        FragranceCategory = c.FragranceCategory,
                        Price = c.Price,
                        BrandID = c.BrandId,

                    }).FirstOrDefault();
            }
            return perfumeDto;
        }

        public PerfumeDto Save(PerfumeDto perfumeDto)
        {

            using (var x = new MakeupApiContext())
            {
                x.Perfumes.Add(new Perfume()
                {
                    Name = perfumeDto.Name,
                    Description = perfumeDto.Description,
                    Gender = perfumeDto.Gender,
                    FragranceCategory = perfumeDto.FragranceCategory,

                    Price = perfumeDto.Price,
                    BrandId = perfumeDto.BrandID,

                });
                x.SaveChanges();
            }
            return perfumeDto;
        }


        public bool Delete(int id)
        {
            if (id == 0) return false;

            try
            {
                Perfume perfume = db.Perfumes.Find(id);
                db.Perfumes.Remove(perfume);
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

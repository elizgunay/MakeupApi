using ApplicationService.DTOs;
using ApplicationService.Implementations;
using Data.Context;
using Data.Entities;
using Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Messages;
using Website.ViewModels;

namespace WebAPI.Controllers
{
    public class BrandController : ApiController
    {
       
        private readonly BrandManagementService _service = null;
        
        public BrandController()
        {
            _service = new BrandManagementService();
        }
       

        [HttpGet]
        // [Route("api/brand")]
        public IHttpActionResult GetAll()
        {
            
            return Json(_service.GetAll());
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            return Json(_service.GetById(id));
        }

        [HttpPost]
        public IHttpActionResult Save(BrandDto brandDto)
        {
            //if (!brandDto.Validate())
            //    return Json(new ResponseMessage { Code = 500, Error = "Data is not valid!" });
           // ResponseMessage response = new ResponseMessage();
          
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.Please recheck!");

            }

            return Json(_service.Save(brandDto));
        }

        public IHttpActionResult Put(BrandVM brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("This is invalid model.Please recheck!");
            }

            using(var x = new MakeupApiContext())
            {
                var checkExsitingBrand = x.Brands.Where(c => c.Id == brand.Id)
                    .FirstOrDefault<Brand>();

                if(checkExsitingBrand != null)
                {
                    checkExsitingBrand.BrandName = brand.BrandName;

                    x.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

            }
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Please enter valid Brand id");

            ResponseMessage response = new ResponseMessage();

            if (_service.Delete(id))
            {
                response.Code = 200;
                response.Body = "Brand is save.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Brand is not save.";
            }

            return Json(response);
        }
    }
}


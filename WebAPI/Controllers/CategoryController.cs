using ApplicationService.DTOs;
using ApplicationService.Implementations;
using Data.Context;
using Data.Entities;
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
    public class CategoryController : ApiController
    {

        private readonly CategoryManagementService _service = null;

        public CategoryController()
        {
            _service = new CategoryManagementService();
        }


        // GET: api/Category
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(_service.GetAll());
        }

        // GET: api/Category/5
        public IHttpActionResult GetById(int id)
        {
            return Json(_service.GetById(id));

        }

        // POST: api/Category
        public IHttpActionResult Save(CategoryDto categoryDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.Please recheck!");

            }

            return Json(_service.Save(categoryDto));
        }

        // PUT: api/Category/5
        public IHttpActionResult Put(CategoryVM category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("This is invalid model.Please recheck!");
            }

            using (var x = new MakeupApiContext())
            {
                var checkExsitingBrand = x.Categories.Where(c => c.Id == category.Id)
                    .FirstOrDefault<Category>();

                if (checkExsitingBrand != null)
                {
                    checkExsitingBrand.CategoryName = category.CategoryName;

                    x.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

            }
            return Ok();
        }


        // DELETE: api/Category/5

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Please enter valid Category id");

            ResponseMessage response = new ResponseMessage();

            if (_service.Delete(id))
            {
                response.Code = 200;
                response.Body = "Category is save.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Category is not save.";
            }

            return Json(response);
        }
    }
}

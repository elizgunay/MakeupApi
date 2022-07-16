using ApplicationService.DTOs;
using ApplicationService.Implementations;
using Data.Context;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPI.Messages;

namespace WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        private readonly ProductManagementService _service = null;

        public ProductController()
        {
            _service = new ProductManagementService();
            

        }

        // GET: api/Product
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(_service.GetAll());
        }

        // GET: api/Product/5
        public IHttpActionResult GetById(int id)
        {
            return Json(_service.GetById(id));

        }

        [HttpPost]
        [Route("upload")]
        public IHttpActionResult Upload(IFormFile file)
        {
            return Ok();
        }

        // POST: api/Product
        public IHttpActionResult Save(ProductDto productDto)
        {

            //var httpRequest = HttpContext.Current.Request;

            //foreach (string file in httpRequest.Files)
            //{
            //    var postedFile = httpRequest.Files[file];
            //    var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
            //    postedFile.SaveAs(filePath);
            //}

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.Please recheck!");
            }

            return Json(_service.Save(productDto));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Please enter valid Product id");

            ResponseMessage response = new ResponseMessage();

            if (_service.Delete(id))
            {
                response.Code = 200;
                response.Body = "Product is save.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Product is not save.";
            }

            return Json(response);
        }

    }
}

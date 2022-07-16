using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Messages;

namespace WebAPI.Controllers
{
    public class PerfumeController : ApiController
    {
        private readonly PerfumeManagementService _service = null;

        public PerfumeController()
        {
            _service = new PerfumeManagementService();
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

        // POST: api/Category
        public IHttpActionResult Save(PerfumeDto perfumeDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.Please recheck!");
            }

            return Json(_service.Save(perfumeDto));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Please enter valid Perfume id");

            ResponseMessage response = new ResponseMessage();

            if (_service.Delete(id))
            {
                response.Code = 200;
                response.Body = "Perfume is save.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Perfume is not save.";
            }

            return Json(response);
        }
    }
}

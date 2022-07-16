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
    public class UserController : ApiController
    {
        private readonly UserManagementService _service = null;

        public UserController()
        {
            _service = new UserManagementService();
        }


        [HttpGet]
        // [Route("api/user")]
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
        public IHttpActionResult Save(UserDto userDto)
        {
           

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.Please recheck!");

            }

            return Json(_service.Save(userDto));
        }

    

        //[HttpDelete]
        //public IHttpActionResult Delete(int id)
        //{
        //    if (id <= 0)
        //        return BadRequest("Please enter valid User id");

        //    ResponseMessage response = new ResponseMessage();

        //    if (_service.Delete(id))
        //    {
        //        response.Code = 200;
        //        response.Body = "User is save.";
        //    }
        //    else
        //    {
        //        response.Code = 500;
        //        response.Body = "User is not save.";
        //    }

        //    return Json(response);
        //}
    }
}

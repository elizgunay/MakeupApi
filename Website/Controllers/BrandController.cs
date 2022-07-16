using Data.Context;
using Data.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Website.ViewModels;
using PagedList.Mvc;
using PagedList;

namespace Website.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        private readonly Uri url = new Uri("http://localhost:51188/api/brand");

        //MakeupApiContext db = new MakeupApiContext();
        // [AllowAnonymous]
        MakeupApiContext db = new MakeupApiContext();
        [AllowAnonymous]
        public ActionResult Index(int? page, string search)
        {

            List<Brand> brands = db.Brands.ToList();
            return View(db.Brands.Where(x => x.BrandName.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1,5));

           

        }
        
   
        public ActionResult Details(int id)
        {
            BrandVM brand = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                var responseTask = client.GetAsync("brand/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BrandVM>();
                    brand = readTask.Result;
                }
            }
            return View(brand);
        }
        // api/brand/create
        [Authorize(Roles = "A")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BrandVM brandVM)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                var postTask = client.PostAsJsonAsync<BrandVM>("brand", brandVM);
                postTask.Wait();

                var postResult = postTask.Result;
                if (postResult.IsSuccessStatusCode)
                    return RedirectToAction("Index");

            }
            ModelState.AddModelError(string.Empty, "Server occured errors.Please check with admin!");

            return View(brandVM);

        }

        // api/brand/edit/id
        [Authorize(Roles = "A")]
        public ActionResult Edit(int id)
        {
            BrandVM brand = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                var responseTask = client.GetAsync("brand/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BrandVM>();
                    brand = readTask.Result;
                }
            }
            return View(brand);
           
        }

        [HttpPost]
        public ActionResult Edit(BrandVM brandVM)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                var putTask = client.PutAsJsonAsync<BrandVM>("brand", brandVM);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(brandVM);
                }
            }

            //try
            //{
            //    using (var client = new HttpClient())
            //    {
            //        client.BaseAddress = url;
            //        client.DefaultRequestHeaders.Accept.Clear();
            //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //        var content = JsonConvert.SerializeObject(brandVM);
            //        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            //        var byteContent = new ByteArrayContent(buffer);
            //        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //        // make the request // Save or Update?
            //        HttpResponseMessage response = await client.PostAsync("save", byteContent);

            //    }

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}


        }

        // api/brand/id
        public ActionResult Delete(int id)
        {
            // string accessToken = await GetAccessToken();

            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                var deleteTask = client.DeleteAsync("brand/" + id.ToString());

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");

            }
            return RedirectToAction("Index");

        }
    }
}
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Website.ViewModels;
using PagedList.Mvc;
using PagedList;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Website.Controllers
{

    public class ProductController : Controller
    {
       

        // GET: Product
        private readonly Uri url = new Uri("http://localhost:51188/api/product");

        [AllowAnonymous]
        //[Authorize(Roles = "A,U")]
        public ActionResult Index(int? page, string search)
        {
            List<Product> products = db.Products.ToList();
            return View(db.Products.Where(x => x.ProductName.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 3));
        }

        MakeupApiContext db = new MakeupApiContext();
        // api/product/create
        [Authorize(Roles = "A")]
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductVM productVM)
        {

            using (var client = new HttpClient())
            {
                //using (var content = new MultipartFormDataContent())
                //{
                //    MemoryStream target = new MemoryStream();
                //    productVM.Image.InputStream.CopyTo(target);
                //    byte[] Bytes = target.ToArray();

                //    productVM.Image.InputStream.Read(Bytes, 0, Bytes.Length);
                //    var fileContent = new ByteArrayContent(Bytes);
                //    fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = productVM.Image.FileName };

                //    content.Add(fileContent);

                //    client.BaseAddress = url;
                //    var postTask = client.PostAsJsonAsync<ProductVM>("product", productVM);
                //    postTask.Wait();

                //    var postResult = postTask.Result;
                //    if (postResult.IsSuccessStatusCode)
                //        return RedirectToAction("Index");
                //}


                client.BaseAddress = url;
                var postTask = client.PostAsJsonAsync<ProductVM>("product", productVM);
                postTask.Wait();

                var postResult = postTask.Result;
                if (postResult.IsSuccessStatusCode)
                    return RedirectToAction("Index");

            }
            ModelState.AddModelError(string.Empty, "Server occured errors.Please check with admin!");
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName", productVM.BrandID);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", productVM.CategoryID);



            return View(productVM);

        }

        public ActionResult Details(int id)
        {
            ProductVM product = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                var responseTask = client.GetAsync("product/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ProductVM>();
                    product = readTask.Result;
                }
            }
            return View(product);
        }



        // api/brand/edit/id
        [Authorize(Roles = "A")]
        public ActionResult Edit(int id)
        {
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");


            ProductVM product = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                var responseTask = client.GetAsync("product/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ProductVM>();
                    product = readTask.Result;
                }
            }
            return View(product);

        }

        [HttpPost]
        public ActionResult Edit(ProductVM productVM)
        {
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName", productVM.BrandID);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", productVM.CategoryID);

            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                var putTask = client.PutAsJsonAsync<ProductVM>("product", productVM);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(productVM);
                }
            }

        }

        public ActionResult Delete(int id)
        {
            // string accessToken = await GetAccessToken();

            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                var deleteTask = client.DeleteAsync("product/" + id.ToString());

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");

            }
            return RedirectToAction("Index");

        }
    }
}
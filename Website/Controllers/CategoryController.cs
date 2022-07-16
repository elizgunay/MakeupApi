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

namespace Website.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly Uri url = new Uri("http://localhost:51188/api/category");
        MakeupApiContext db = new MakeupApiContext();
        [AllowAnonymous]
        public ActionResult Index(int? page,string search)
        {
         
            List<Category> categories = db.Categories.ToList();
            return View(db.Categories.Where(x => x.CategoryName.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 3));


        }

        public ActionResult Details(int id)
        {
            CategoryVM category = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                var responseTask = client.GetAsync("category/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CategoryVM>();
                    category = readTask.Result;
                }
            }
            return View(category); 
        }
          
        [Authorize(Roles = "A")]
        // api/category/create
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryVM categoryVM)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                var postTask = client.PostAsJsonAsync<CategoryVM>("category", categoryVM);
                postTask.Wait();

                var postResult = postTask.Result;
                if (postResult.IsSuccessStatusCode)
                    return RedirectToAction("Index");

            }
            ModelState.AddModelError(string.Empty, "Server occured errors.Please check with admin!");

            return View(categoryVM);

        }

        // api/category/edit/id
        [Authorize(Roles ="A")]
        public ActionResult Edit(int id)
        {
            CategoryVM category = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                var responseTask = client.GetAsync("category/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CategoryVM>();
                    category = readTask.Result;
                }
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(CategoryVM categoryVM)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                var putTask = client.PutAsJsonAsync<CategoryVM>("category", categoryVM);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(categoryVM);
                }
            }

        }

        public ActionResult Delete(int id)
        {
            // string accessToken = await GetAccessToken();

            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                var deleteTask = client.DeleteAsync("category/" + id.ToString());

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");

            }
            return RedirectToAction("Index");

        }
    }
}
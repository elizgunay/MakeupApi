using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data.Context;
using Data.Entities;
using PagedList.Mvc;
using PagedList;

namespace Website.Controllers
{
    public class PerfumesController : Controller
    {
        private MakeupApiContext db = new MakeupApiContext();
       // int page_size = 2;
        // GET: Perfumes
        [AllowAnonymous]
        public ActionResult Index(int? page,string search)
        {
            //var data = (from s in db.Perfumes select s);
            //if (page > 0)
            //{
            //    page = page;
            //}
            //else
            //{
            //    page = 1;
            //}
            //int limit = 3;
            //int start = (int)(page - 1) * limit;
            //int totalProduct = data.Count();
            //ViewBag.totalProduct = totalProduct;
            //ViewBag.pageCurrent = page;
            //float numberPage = (float)totalProduct / limit;
            //ViewBag.numberPage =(int)Math.Ceiling(numberPage);
            //var dataProduct = db.Perfumes.Include(p=>p.Brand).OrderByDescending(s => s.Id).Skip(start).Take(limit);

            ////var perfumes = db.Perfumes.Include(p => p.Brand).OrderBy(a => a.Name)
            ////    .Skip(page*page_size)
            ////    .Take(page_size);

            //return View(dataProduct.ToList());


            List<Perfume> perfumes = db.Perfumes.ToList();
            return View(db.Perfumes.Where(x => x.Name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 3));
        }

        // GET: Perfumes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfume perfume = db.Perfumes.Find(id);
            if (perfume == null)
            {
                return HttpNotFound();
            }
            return View(perfume);
        }

        // GET: Perfumes/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName");
            return View();
        }

        // POST: Perfumes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Gender,FragranceCategory,Price,BrandId,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] Perfume perfume)
        {

            if (ModelState.IsValid)
            {
                db.Perfumes.Add(perfume);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName", perfume.BrandId);
            return View(perfume);
        }

        // GET: Perfumes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfume perfume = db.Perfumes.Find(id);
            if (perfume == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName", perfume.BrandId);
            return View(perfume);
        }

        // POST: Perfumes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Gender,FragranceCategory,Price,BrandId,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] Perfume perfume)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfume).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName", perfume.BrandId);
            return View(perfume);
        }

        // GET: Perfumes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfume perfume = db.Perfumes.Find(id);
            if (perfume == null)
            {
                return HttpNotFound();
            }
            return View(perfume);
        }

        // POST: Perfumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perfume perfume = db.Perfumes.Find(id);
            db.Perfumes.Remove(perfume);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

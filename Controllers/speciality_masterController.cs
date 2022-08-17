using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using canteen_management_system.Models;

namespace canteen_management_system.Controllers
{
    public class speciality_masterController : Controller
    {
        private canteen_manege_systemEntities13 db = new canteen_manege_systemEntities13();

        // GET: speciality_master
        public ActionResult Index()
        {
            var speciality_master = db.speciality_master.Include(s => s.food_category_master).Include(s => s.user_master);
            return View(speciality_master.ToList());
        }

        // GET: speciality_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            speciality_master speciality_master = db.speciality_master.Find(id);
            if (speciality_master == null)
            {
                return HttpNotFound();
            }
            return View(speciality_master);
        }

        // GET: speciality_master/Create
        public ActionResult Create()
        {
            ViewBag.food_cat_id = new SelectList(db.food_category_master, "food_cat_id", "food_cat_name");
            ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name");
            return View();
        }

        // POST: speciality_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "speciality_id,user_id,food_cat_id,qualification,experience,is_approed,is_active,is_delete")] speciality_master speciality_master)
        {
            if (ModelState.IsValid)
            {
                var data = db.user_master.Max(x=>x.user_id);
                speciality_master.user_id = data;
                db.speciality_master.Add(speciality_master);
                db.SaveChanges();
                return RedirectToAction("Index", "chef_collect_order_master");
            }

            ViewBag.food_cat_id = new SelectList(db.food_category_master, "food_cat_id", "food_cat_name", speciality_master.food_cat_id);
            ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name", speciality_master.user_id);
            return View(speciality_master);
        }

        // GET: speciality_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            speciality_master speciality_master = db.speciality_master.Find(id);
            if (speciality_master == null)
            {
                return HttpNotFound();
            }
            ViewBag.food_cat_id = new SelectList(db.food_category_master, "food_cat_id", "food_cat_name", speciality_master.food_cat_id);
            ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name", speciality_master.user_id);
            return View(speciality_master);
        }

        // POST: speciality_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "speciality_id,user_id,food_cat_id,qualification,experience,is_approed,is_active,is_delete")] speciality_master speciality_master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(speciality_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.food_cat_id = new SelectList(db.food_category_master, "food_cat_id", "food_cat_name", speciality_master.food_cat_id);
            ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name", speciality_master.user_id);
            return View(speciality_master);
        }

        // GET: speciality_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            speciality_master speciality_master = db.speciality_master.Find(id);
            if (speciality_master == null)
            {
                return HttpNotFound();
            }
            return View(speciality_master);
        }

        // POST: speciality_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            speciality_master speciality_master = db.speciality_master.Find(id);
            db.speciality_master.Remove(speciality_master);
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

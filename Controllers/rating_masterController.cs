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
    public class rating_masterController : Controller
    {
        private canteen_manege_systemEntities13 db = new canteen_manege_systemEntities13();

        public ActionResult Show()
        {
            return View();
        }

        // GET: rating_master
        public ActionResult Index()
        {
            var rating_master = db.rating_master.Include(r => r.food_item_master).Include(r => r.user_master);
            return View(db.rating_master.Where(f=>f.is_delete==false || f.is_delete==null).ToList());
        }

        // GET: rating_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rating_master rating_master = db.rating_master.Find(id);
            
            if (rating_master == null)
            {
                return HttpNotFound();
            }
            return View(rating_master);
        }

        // GET: rating_master/Create
        public ActionResult Create()
        {
            
                ViewBag.food_item_id = new SelectList(db.food_item_master, "food_item_id", "item_name");
                ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name");
                return View();
            
        }

        // POST: rating_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rating_id,food_item_id,rating,create_datetime,update_datetime,is_active,is_delete,user_id")] rating_master rating_master,int rating)
        {
            if (ModelState.IsValid)
            {              
                        var data = Session["user_id"];
                        rating_master.user_id = Convert.ToInt32(data);
                        rating_master.create_datetime = DateTime.Now;
                        rating_master.rating = rating;
                        db.rating_master.Add(rating_master);
                        db.SaveChanges();
                        return RedirectToAction("Show");      
       
            }

            ViewBag.food_item_id = new SelectList(db.food_item_master, "food_item_id", "item_name", rating_master.food_item_id);
            ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name", rating_master.user_id);
            return View(rating_master);
        }


        public ActionResult Create1(int id)
        {
            Session["f_item_id"] = id;
            var data1 = Session["user_id"];
            if (data1 == null)
            {
                return RedirectToAction("Checkout", "ShoppingCart");
            }
            else
            {
                ViewBag.food_item_id = new SelectList(db.food_item_master, "food_item_id", "item_name");
                ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name");
                return View();
            }
        }

      [HttpPost]
        public ActionResult Create1(FormCollection fc)
        {
            rating_master rating_Master = new rating_master();
            var data = Session["user_id"];
            rating_Master.user_id = Convert.ToInt32(data);
            rating_Master.create_datetime = DateTime.Now;
            rating_Master.rating = Convert.ToInt32(fc["rating"]);
            var data1 = Session["f_item_id"];
            rating_Master.food_item_id = Convert.ToInt32(data1);
            db.rating_master.Add(rating_Master);
            db.SaveChanges();
            return RedirectToAction("Show");
        }
        // GET: rating_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rating_master rating_master = db.rating_master.Find(id);
            if (rating_master == null)
            {
                return HttpNotFound();
            }
            Session["f_c_id"] = rating_master.food_item_id;
            Session["us_id"] = rating_master.user_id;
            Session["rsting"] = rating_master.rating;
            ViewBag.food_item_id = new SelectList(db.food_item_master, "food_item_id", "item_name", rating_master.food_item_id);
            ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name", rating_master.user_id);
            return View(rating_master);
        }

        // POST: rating_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rating_id,food_item_id,rating,create_datetime,update_datetime,is_active,is_delete,user_id")] rating_master rating_master)
        {
            if (ModelState.IsValid)
            {
              
                var data1 = Session["f_c_id"];
                rating_master.food_item_id = Convert.ToInt32(data1);
                var data2 = Session["us_id"];
                rating_master.user_id = Convert.ToInt32(data2);
                var data3 = Session["rsting"];
                rating_master.rating = Convert.ToInt32(data3);
                db.Entry(rating_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.food_item_id = new SelectList(db.food_item_master, "food_item_id", "item_name", rating_master.food_item_id);
            ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name", rating_master.user_id);
            return View(rating_master);
        }

        // GET: rating_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rating_master rating_master = db.rating_master.Find(id);
            if (rating_master == null)
            {
                return HttpNotFound();
            }
            return View(rating_master);
        }

        // POST: rating_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rating_master rating_master = db.rating_master.Find(id);
            db.rating_master.Remove(rating_master);
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

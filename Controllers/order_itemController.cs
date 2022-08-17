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
    public class order_itemController : Controller
    {
        private canteen_manege_systemEntities13 db = new canteen_manege_systemEntities13();

        // GET: order_item
        public ActionResult Index()
        {
            var order_item = db.order_item.Include(o => o.food_item_master).Include(o => o.order_master);
            return View(order_item.ToList());
        }

        // GET: order_item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_item order_item = db.order_item.Find(id);
            if (order_item == null)
            {
                return HttpNotFound();
            }
            return View(order_item);
        }

        // GET: order_item/Create
        public ActionResult Create()
        {
            ViewBag.food_item_id = new SelectList(db.food_item_master, "food_item_id", "item_name");
            ViewBag.order_master_id = new SelectList(db.order_master, "order_master_id", "order_master_id");
            return View();
        }

        // POST: order_item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "order_item_id,order_master_id,food_item_id,total_price,status,create_datetime,update_datetime,is_active,is_delete")] order_item order_item)
        {
            if (ModelState.IsValid)
            {
                db.order_item.Add(order_item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.food_item_id = new SelectList(db.food_item_master, "food_item_id", "item_name", order_item.food_item_id);
            ViewBag.order_master_id = new SelectList(db.order_master, "order_master_id", "order_master_id", order_item.order_master_id);
            return View(order_item);
        }

        // GET: order_item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_item order_item = db.order_item.Find(id);
            if (order_item == null)
            {
                return HttpNotFound();
            }
            ViewBag.food_item_id = new SelectList(db.food_item_master, "food_item_id", "item_name", order_item.food_item_id);
            ViewBag.order_master_id = new SelectList(db.order_master, "order_master_id", "order_master_id", order_item.order_master_id);
            return View(order_item);
        }

        // POST: order_item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "order_item_id,order_master_id,food_item_id,total_price,status,create_datetime,update_datetime,is_active,is_delete")] order_item order_item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.food_item_id = new SelectList(db.food_item_master, "food_item_id", "item_name", order_item.food_item_id);
            ViewBag.order_master_id = new SelectList(db.order_master, "order_master_id", "order_master_id", order_item.order_master_id);
            return View(order_item);
        }

        // GET: order_item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_item order_item = db.order_item.Find(id);
            if (order_item == null)
            {
                return HttpNotFound();
            }
            return View(order_item);
        }

        // POST: order_item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order_item order_item = db.order_item.Find(id);
            db.order_item.Remove(order_item);
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

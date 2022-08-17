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
    public class feedback_masterController : Controller
    {
        private canteen_manege_systemEntities13 db = new canteen_manege_systemEntities13();

        // GET: feedback_master
        public ActionResult Index()
        {
            var feedback_master = db.feedback_master.Include(f => f.user_master);
            return View(feedback_master.Where(f=>f.is_delete==false || f.is_delete==null).ToList());
        }

        // GET: feedback_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedback_master feedback_master = db.feedback_master.Find(id);
            if (feedback_master == null)
            {
                return HttpNotFound();
            }
            return View(feedback_master);
        }

        // GET: feedback_master/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name");
            return View();
        }

        // POST: feedback_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "feedback_id,user_id,feedback,create_datetime,update_datetime,is_active,is_delete")] feedback_master feedback_master)
        {
            if (ModelState.IsValid)
            {
                var data = Session["user_id"];
                feedback_master.user_id = Convert.ToInt32(data);
                feedback_master.create_datetime = DateTime.Now;
                db.feedback_master.Add(feedback_master);
                db.SaveChanges();
                return RedirectToAction("feedback_success","Home");
            }

            ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name", feedback_master.user_id);
            return View(feedback_master);
        }

        // GET: feedback_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedback_master feedback_master = db.feedback_master.Find(id);
            
            if (feedback_master == null)
            {
                return HttpNotFound();
            }
            Session["u_id"] = feedback_master.user_id;
            Session["feedback"] = feedback_master.feedback;
            ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name", feedback_master.user_id);
            return View(feedback_master);
        }

        // POST: feedback_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "feedback_id,user_id,feedback,create_datetime,update_datetime,is_active,is_delete")] feedback_master feedback_master)
        {
            if (ModelState.IsValid)
            {
                var data = Session["u_id"];
                feedback_master.user_id = Convert.ToInt32(data);
                var data1 = Session["feedback"];
                feedback_master.feedback = Convert.ToString(data1);
                feedback_master.update_datetime = DateTime.Now;
                db.Entry(feedback_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name", feedback_master.user_id);
            return View(feedback_master);
        }

        // GET: feedback_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedback_master feedback_master = db.feedback_master.Find(id);
            if (feedback_master == null)
            {
                return HttpNotFound();
            }
            return View(feedback_master);
        }

        // POST: feedback_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            feedback_master feedback_master = db.feedback_master.Find(id);
            db.feedback_master.Remove(feedback_master);
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

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
    public class payment_masterController : Controller
    {
        private canteen_manege_systemEntities13 db = new canteen_manege_systemEntities13();

        public ActionResult show(){
            return View();
        }

        // GET: payment_master
        public ActionResult Index()
        {
            var payment_master = db.payment_master.Include(p => p.order_master);
            return View(db.payment_master.Where(f=>f.is_delete==false).ToList());
        }

        // GET: payment_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            payment_master payment_master = db.payment_master.Find(id);
            if (payment_master == null)
            {
                return HttpNotFound();
            }
            return View(payment_master);
        }

        public ActionResult Create_1()
        {
            ViewBag.order_master_id = new SelectList(db.order_master, "order_master_id", "order_master_id");
            return View();
        }

        // POST: payment_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_1([Bind(Include = "payment_id,order_master_id,payment_mode,create_datetime,update_datetime,is_active,is_delete")] payment_master payment_master, order_master order_Master, user_master user_Master)
        {
            if (ModelState.IsValid)
            {
               
                    return RedirectToAction("payment","ShoppingCart");
                
            }

            ViewBag.order_master_id = new SelectList(db.order_master, "order_master_id", "order_master_id", payment_master.order_master_id);
            return View(payment_master);
        }

        // GET: payment_master/Create
        public ActionResult Create()
        {
            ViewBag.order_master_id = new SelectList(db.order_master, "order_master_id", "order_master_id");
            return View();
        }

        // POST: payment_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "payment_id,order_master_id,payment_mode,create_datetime,update_datetime,is_active,is_delete")] payment_master payment_master, order_master order_Master,user_master user_Master )
        {
            if (ModelState.IsValid)
            {

                //var da = Session["user_id"];
                //var ch = Convert.ToInt32(da);
                //var data= db.order_master.Where(m=>m.user_id==ch).FirstOrDefault();
                //payment_master.order_master_id=Convert.ToInt32(data.order_master_id);
                //object lastId = table.Rows[table.Rows.Count - 1]["ID"];
                //int maxValue = table.AsEnumerable().Select(row => Convert.ToInt32(row["order_master_id"])).Max();
                var max = db.order_master.Max(x => x.order_master_id);
                payment_master.order_master_id = max;
                payment_master.create_datetime = DateTime.Now;
                db.payment_master.Add(payment_master);
                db.SaveChanges();
                return RedirectToAction("show");
            }

            ViewBag.order_master_id = new SelectList(db.order_master, "order_master_id", "order_master_id", payment_master.order_master_id);
            return View(payment_master);
        }

        // GET: payment_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            payment_master payment_master = db.payment_master.Find(id);
            Session["order_mas_id"] = payment_master.order_master_id;
            if (payment_master == null)
            {
                return HttpNotFound();
            }
            Session["pay_mode"] = payment_master.payment_mode;
            ViewBag.order_master_id = new SelectList(db.order_master, "order_master_id", "order_master_id", payment_master.order_master_id);
            return View(payment_master);
        }

        // POST: payment_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "payment_id,order_master_id,payment_mode,create_datetime,update_datetime,is_active,is_delete")] payment_master payment_master)
        {
            if (ModelState.IsValid)
            {
                var data = Session["order_mas_id"];
                payment_master.order_master_id = Convert.ToInt32(data);
                payment_master.update_datetime = DateTime.Now;
                var data1 = Session["pay_mode"];
                payment_master.payment_mode = Convert.ToInt32(data1);
                db.Entry(payment_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.order_master_id = new SelectList(db.order_master, "order_master_id", "order_master_id", payment_master.order_master_id);
            return View(payment_master);
        }

        // GET: payment_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            payment_master payment_master = db.payment_master.Find(id);
            if (payment_master == null)
            {
                return HttpNotFound();
            }
            return View(payment_master);
        }

        // POST: payment_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            payment_master payment_master = db.payment_master.Find(id);
            db.payment_master.Remove(payment_master);
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

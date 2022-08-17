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
    public class order_masterController : Controller
    {
        private canteen_manege_systemEntities13 db = new canteen_manege_systemEntities13();

        public ActionResult message()
        {
            Session["b"]=null;
            //Session.Abandon();
           // Session.Clear();
            var data = Session["user_id"];
            var s = Convert.ToInt32(data);
            
            // if (Session["user_id"]==db.order_master.Where(f=>f.user_id==Convert.ToInt32(data)))
            var currentDate = DateTime.Now;
            return View(db.order_master.Where(f => f.status == "order cancelled" || f.status== "order is being prepared start" || f.status== "order is ready").Where(f => f.user_id == s).Where(f=>f.create_date== currentDate.Date).ToList());


        }
        // GET: order_master
        public ActionResult Index()
        {

            // var order_master = db.order_master.Include(o => o.food_item_master).Include(o => o.user_master);
            var date = DateTime.Now.Date;
            return View(db.order_master.Where(f=>f.create_date==date).ToList());
        }

        // GET: order_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_master order_master = db.order_master.Find(id);
            if (order_master == null)
            {
                return HttpNotFound();
            }
            return View(order_master);
        }


        // GET: order_master/Create
        public ActionResult orderfromcart()
        {
            ViewBag.name = Session["user_name"];
            ViewBag.food_item_id = new SelectList(db.food_item_master, "food_item_id", "item_name");
            ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name");
            return View();
        }

        // POST: order_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult orderfromcart([Bind(Include = "order_master_id,user_id,food_item_id,total_price,quantity,order_deliverytime,order_date,create_datetime,update_datetime,is_active,is_delete")] order_master order_master)
        {
            if (ModelState.IsValid)
            {

                var abc = Session["user_id"];
                order_master.user_id = Convert.ToInt32(abc);
                var x=Session["cart"];
                var a=(int)x;
                order_master.quantity = a;
                order_master.create_date = DateTime.Now;
                order_master.create_time = DateTime.Now.TimeOfDay;
                db.order_master.Add(order_master);
                db.SaveChanges();
                return RedirectToAction("Create", "payment_master");
            }

            ViewBag.food_item_id = new SelectList(db.food_item_master, "food_item_id", "item_name", order_master.food_item_id);
            ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name", order_master.user_id);
            return View(order_master);
        }

        // GET: order_master/Create
        public ActionResult Create()
        {
            ViewBag.name = Session["user_name"];
            ViewBag.food_item_id = new SelectList(db.food_item_master.Where(f=>f.is_delete==false), "food_item_id", "item_name");
            ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name");
            return View();
        }

        // POST: order_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "order_master_id,user_id,food_item_id,total_price,quantity,order_deliverytime,order_date,create_datetime,update_datetime,is_active,is_delete")] order_master order_master)
        {
            if (ModelState.IsValid)
            
           {

                var abc = Session["user_id"];
                order_master.user_id = Convert.ToInt32(abc);
                var dat = order_master.order_date;
                order_master.order_date = Convert.ToDateTime(dat).Date;
                order_master.order_deliverytime = order_master.order_deliverytime;
                var x = db.food_item_master.Where(f => f.food_item_id == order_master.food_item_id).FirstOrDefault();
                var dis=x.amount * 1 * (x.discount) / 100;
                order_master.total_price =x.amount*1-dis ;
                order_master.quantity = 1;
                order_master.create_date = DateTime.Now.Date;
                order_master.create_time = DateTime.Now.TimeOfDay;
                db.order_master.Add(order_master);
                db.SaveChanges();
                order_assign_master order_Assign_Master = new order_assign_master();
                order_Assign_Master.order_master_id = order_master.order_master_id;
                db.order_assign_master.Add(order_Assign_Master);
                db.SaveChanges();
                return RedirectToAction("Create","payment_master");
            }

            ViewBag.food_item_id = new SelectList(db.food_item_master, "food_item_id", "item_name", order_master.food_item_id);
            ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name", order_master.user_id);
            return View(order_master);
        }

        // GET: order_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_master order_master = db.order_master.Find(id);
            if (order_master == null)
            {
                return HttpNotFound();
            }
            ViewBag.food_item_id = new SelectList(db.food_item_master, "food_item_id", "item_name", order_master.food_item_id);
            ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name", order_master.user_id);
            return View(order_master);
        }

        // POST: order_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "order_master_id,user_id,food_item_id,total_price,quantity,order_deliverytime,order_date,create_datetime,update_datetime,is_active,is_delete")] order_master order_master)
        {
            if (ModelState.IsValid)
            {
                order_master.update_datetime = DateTime.Now;
                db.Entry(order_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.food_item_id = new SelectList(db.food_item_master, "food_item_id", "item_name", order_master.food_item_id);
            ViewBag.user_id = new SelectList(db.user_master, "user_id", "first_name", order_master.user_id);
            return View(order_master);
        }

        // GET: order_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_master order_master = db.order_master.Find(id);
            if (order_master == null)
            {
                return HttpNotFound();
            }
            return View(order_master);
        }

        // POST: order_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order_master order_master = db.order_master.Find(id);
            db.order_master.Remove(order_master);
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

        [HttpGet]
        public ActionResult calcu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult calcu(order_master order_Master)
        {
            if (ModelState.IsValid)
            {
                var x = order_Master.food_item_master.amount * order_Master.quantity;
                db.Entry(x).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Create");
        }
    }
}

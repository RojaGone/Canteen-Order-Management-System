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
    public class chef_collect_order_masterController : Controller
    {
        private canteen_manege_systemEntities13 db = new canteen_manege_systemEntities13();

        //public ActionResult save(chef_collect_order_master chef_collect_order_master,int id)
        //{
        //    order_master order_Master = new order_master();
        //    chef_collect_order_master.Order_assign_id = order_Master.order_master_id;
        //    db.chef_collect_order_master.Add(chef_collect_order_master);
        //    db.SaveChanges();
        //    return Redirect("Index");
        //}
        // GET: chef_collect_order_master

        public ActionResult Reject(int id)
        {

            if (ModelState.IsValid)
            {

                if (Session["cart1"] == null)
                {
                    Session.Remove("cart1");
                    List<Item> cart1 = new List<Item>();
                    cart1.Add(new Item(db.food_item_master.Find(id), 1));
                    Session["cart1"] = cart1;
                    chef_collect_order_master chef_collect_order_master = db.chef_collect_order_master.Find(id);
                    var d = db.order_master.Where(f => f.user_id == chef_collect_order_master.order_assign_master.order_master.user_id).FirstOrDefault();
                    if (d.user_id != null)
                    {
                        Session["abc"] = d.user_id;
                        Session["b"] = cart1.Count;
                        chef_collect_order_master chef_collect_order_master1 = db.chef_collect_order_master.Find(id);
                        order_master order_Master = db.order_master.Find(chef_collect_order_master1.order_assign_master.order_master_id);
                        order_Master.status = "order cancelled";
                        db.Entry(order_Master).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        //Session.Remove("cart");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Session["b"] = cart1.Count;
                        chef_collect_order_master chef_collect_order_master2 = db.chef_collect_order_master.Find(id);
                        order_master order_Master = db.order_master.Find(chef_collect_order_master2.order_assign_master.order_master_id);
                        order_Master.status = "order cancelled";
                        db.Entry(order_Master).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        //Session.Remove("cart");
                        // return RedirectToAction("save", new { id = chef_collect_order_master2.order_assign_master.Order_assign_id });
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    List<Item> cart1 = (List<Item>)Session["cart1"];
                    int index = isExisting(id);
                    if (index == -1)
                        cart1.Add(new Item(db.food_item_master.Find(id), 1));
                    else
                        cart1[index].Quantity++;
                    Session["cart1"] = cart1;


                    Session["b"] = cart1.Count;
                    chef_collect_order_master chef_collect_order_master2 = db.chef_collect_order_master.Find(id);
                    order_master order_Master = db.order_master.Find(chef_collect_order_master2.order_assign_master.order_master_id);
                    order_Master.status = "order cancelled";
                    db.Entry(order_Master).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    //Session.Remove("cart");
                    //return RedirectToAction("save", new { id = order_Assign_Master.Order_assign_id });
                    return RedirectToAction("Index");

                }
            }
            else
            {

            }


            return View("Index");
        }

        public ActionResult is_done(int id)
        {
            if (ModelState.IsValid)
            {

                if (Session["cart1"] == null)
                {
                    Session.Remove("cart1");
                    List<Item> cart1 = new List<Item>();
                    cart1.Add(new Item(db.food_item_master.Find(id), 1));
                    Session["cart1"] = cart1;
                    chef_collect_order_master chef_collect_order_master = db.chef_collect_order_master.Find(id);
                    var d = db.order_master.Where(f => f.user_id == chef_collect_order_master.order_assign_master.order_master.user_id).FirstOrDefault();
                    if (d.user_id != null)
                    {
                        Session["abc"] = d.user_id;
                        Session["b"] = cart1.Count;
                        chef_collect_order_master chef_collect_order_master1 = db.chef_collect_order_master.Find(id);
                        order_master order_Master = db.order_master.Find(chef_collect_order_master1.order_assign_master.order_master_id);
                        order_Master.status = "order is ready";
                        db.Entry(order_Master).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        //Session.Remove("cart");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Session["b"] = cart1.Count;
                        chef_collect_order_master chef_collect_order_master2 = db.chef_collect_order_master.Find(id);
                        order_master order_Master = db.order_master.Find(chef_collect_order_master2.order_assign_master.order_master_id);
                        order_Master.status = "order cancelled";
                        db.Entry(order_Master).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        //Session.Remove("cart");
                        // return RedirectToAction("save", new { id = chef_collect_order_master2.order_assign_master.Order_assign_id });
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    List<Item> cart1 = (List<Item>)Session["cart1"];
                    int index = isExisting(id);
                    if (index == -1)
                        cart1.Add(new Item(db.food_item_master.Find(id), 1));
                    else
                        cart1[index].Quantity++;
                    Session["cart1"] = cart1;


                    Session["b"] = cart1.Count;
                    chef_collect_order_master chef_collect_order_master2 = db.chef_collect_order_master.Find(id);
                    order_master order_Master = db.order_master.Find(chef_collect_order_master2.order_assign_master.order_master_id);
                    order_Master.status = "order is ready";
                    db.Entry(order_Master).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    //Session.Remove("cart");
                    //return RedirectToAction("save", new { id = order_Assign_Master.Order_assign_id });
                    return RedirectToAction("Index");

                }
            }
            else
            {

            }
            return RedirectToAction("Index");
        }


        public int isExisting(int id)
        {
            chef_collect_order_master chef_collect_order_master = db.chef_collect_order_master.Find(id);
            order_master order_Master = db.order_master.Find(chef_collect_order_master.order_assign_master.order_master_id);
            List<Item> cart1 = (List<Item>)Session["cart1"];
            for (int i = 0; i < cart1.Count; i++)
                if (cart1[i].order_Masters.order_master_id == order_Master.order_master_id)
                    return i;
            return -1;
        }

        public ActionResult is_start(int id)
        {
            if (ModelState.IsValid)
            {

                if (Session["cart1"] == null)
                {
                    Session.Remove("cart1");
                    List<Item> cart1 = new List<Item>();
                    cart1.Add(new Item(db.food_item_master.Find(id), 1));
                    Session["cart1"] = cart1;
                    chef_collect_order_master chef_collect_order_master = db.chef_collect_order_master.Find(id);
                    var d = db.order_master.Where(f => f.user_id == chef_collect_order_master.order_assign_master.order_master.user_id).FirstOrDefault();
                    if (d.user_id != null)
                    {
                        Session["abc"] = d.user_id;
                        Session["b"] = cart1.Count;
                        chef_collect_order_master chef_collect_order_master1 = db.chef_collect_order_master.Find(id);
                        order_master order_Master = db.order_master.Find(chef_collect_order_master1.order_assign_master.order_master_id);
                        order_Master.status = "order is being prepared start";
                        db.Entry(order_Master).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        //Session.Remove("cart");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Session["b"] = cart1.Count;
                        chef_collect_order_master chef_collect_order_master2 = db.chef_collect_order_master.Find(id);
                        order_master order_Master = db.order_master.Find(chef_collect_order_master2.order_assign_master.order_master_id);
                        order_Master.status = "order cancelled";
                        db.Entry(order_Master).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        //Session.Remove("cart");
                        // return RedirectToAction("save", new { id = chef_collect_order_master2.order_assign_master.Order_assign_id });
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    List<Item> cart1 = (List<Item>)Session["cart1"];
                    int index = isExisting(id);
                    if (index == -1)
                        cart1.Add(new Item(db.food_item_master.Find(id), 1));
                    else
                        cart1[index].Quantity++;
                    Session["cart1"] = cart1;


                    Session["b"] = cart1.Count;
                    chef_collect_order_master chef_collect_order_master2 = db.chef_collect_order_master.Find(id);
                    order_master order_Master = db.order_master.Find(chef_collect_order_master2.order_assign_master.order_master_id);
                    order_Master.status = "order is being prepared start";
                    order_Master.update_datetime = DateTime.Now;
                    db.Entry(order_Master).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    //Session.Remove("cart");
                    //return RedirectToAction("save", new { id = order_Assign_Master.Order_assign_id });
                    return RedirectToAction("Index");

                }
            }
            else
            {

            }
            return RedirectToAction("Index");
        }

            public ActionResult Index()
        {
            var chef_collect_order_master = db.chef_collect_order_master.Include(c => c.order_assign_master);
            // return View(chef_collect_order_master.Where(f => f.is_delete == false).Where(f => f.order_assign_master.order_master.status == null).ToList());
            return View(chef_collect_order_master.Where(f => f.is_delete == false).Where(f => f.order_assign_master.order_master.status == "order is ready" || f.order_assign_master.order_master.status == "order is being ready" || f.order_assign_master.order_master.status == "order is being prepared start" || f.order_assign_master.order_master.status == null).ToList());
        }

        public ActionResult Index1()
        {
            var chef_collect_order_master = db.chef_collect_order_master.Include(c => c.order_assign_master);
             return View(chef_collect_order_master.Where(f => f.is_delete == false).Where(f => f.order_assign_master.order_master.status == "order is ready" || f.order_assign_master.order_master.status == "order is being ready" || f.order_assign_master.order_master.status == "order is being prepared start" || f.order_assign_master.order_master.status == null).ToList());
           // return View(db.chef_collect_order_master.Where(f => f.is_delete == false));
        }


        // GET: chef_collect_order_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chef_collect_order_master chef_collect_order_master = db.chef_collect_order_master.Find(id);
            if (chef_collect_order_master == null)
            {
                return HttpNotFound();
            }
            return View(chef_collect_order_master);
        }

        // GET: chef_collect_order_master/Create
        public ActionResult Create()
        {
            ViewBag.Order_assign_id = new SelectList(db.order_assign_master, "Order_assign_id", "Order_assign_id");
            return View();
        }

        // POST: chef_collect_order_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "chef_collect_order_id,Order_assign_id,is_start,is_done,is_active,is_delete,create_datetime,update_datetime")] chef_collect_order_master chef_collect_order_master)
        {
            if (ModelState.IsValid)
            {
                db.chef_collect_order_master.Add(chef_collect_order_master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Order_assign_id = new SelectList(db.order_assign_master, "Order_assign_id", "Order_assign_id", chef_collect_order_master.Order_assign_id);
            return View(chef_collect_order_master);
        }

        // GET: chef_collect_order_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chef_collect_order_master chef_collect_order_master = db.chef_collect_order_master.Find(id);
            Session["order_ass_id"] = chef_collect_order_master.Order_assign_id;
            if (chef_collect_order_master == null)
            {
                return HttpNotFound();
            }
            ViewBag.Order_assign_id = new SelectList(db.order_assign_master, "Order_assign_id", "Order_assign_id", chef_collect_order_master.Order_assign_id);
            return View(chef_collect_order_master);
        }

        // POST: chef_collect_order_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "chef_collect_order_id,Order_assign_id,is_start,is_done,is_active,is_delete,create_datetime,update_datetime")] chef_collect_order_master chef_collect_order_master)
        {
            if (ModelState.IsValid)
            {
                var data = Session["order_ass_id"];
                chef_collect_order_master.Order_assign_id = Convert.ToInt32(data);
                db.Entry(chef_collect_order_master).State = EntityState.Modified;
                db.SaveChanges();
                //if (chef_collect_order_master.is_start == true)
                //{
                //    //send notification code
                //}
                if (chef_collect_order_master.is_start == true && chef_collect_order_master.is_done == false)
                {
                    return RedirectToAction("is_start",new { id = chef_collect_order_master.chef_collect_order_id });
                }
                else if(chef_collect_order_master.is_done == true && chef_collect_order_master.is_done == true)
                {
                    return RedirectToAction("is_done", new { id = chef_collect_order_master.chef_collect_order_id });
                }
                else
                return RedirectToAction("Index");
            }
            ViewBag.Order_assign_id = new SelectList(db.order_assign_master, "Order_assign_id", "Order_assign_id", chef_collect_order_master.Order_assign_id);
            return View(chef_collect_order_master);
        }

        // GET: chef_collect_order_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chef_collect_order_master chef_collect_order_master = db.chef_collect_order_master.Find(id);
            if (chef_collect_order_master == null)
            {
                return HttpNotFound();
            }
            return View(chef_collect_order_master);
        }

        // POST: chef_collect_order_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chef_collect_order_master chef_collect_order_master = db.chef_collect_order_master.Find(id);
            db.chef_collect_order_master.Remove(chef_collect_order_master);
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

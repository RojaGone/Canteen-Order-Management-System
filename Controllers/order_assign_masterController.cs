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
    public class order_assign_masterController : Controller
    {
        private canteen_manege_systemEntities13 db = new canteen_manege_systemEntities13();

     
            public ActionResult save(chef_collect_order_master chef_collect_order_master, int id)
        {
           // order_master order_Master = new order_master();
            chef_collect_order_master.Order_assign_id = id;
            db.chef_collect_order_master.Add(chef_collect_order_master);
            db.SaveChanges();
            return RedirectToAction("Index","order_assign_master");
        }

        //public ActionResult save2(chef_collect_order_master chef_collect_order_master, int id)
        //{
        //    // order_master order_Master = new order_master();
        //    chef_collect_order_master.Order_assign_id = id;
        //    db.chef_collect_order_master.Add(chef_collect_order_master);
        //    db.SaveChanges();
        //    return RedirectToAction("Index2", "chef_collect_order_master");
        //}

        //public ActionResult save3(chef_collect_order_master chef_collect_order_master, int id)
        //{
        //    // order_master order_Master = new order_master();
        //    chef_collect_order_master.Order_assign_id = id;
        //    db.chef_collect_order_master.Add(chef_collect_order_master);
        //    db.SaveChanges();
        //    return RedirectToAction("Index3", "chef_collect_order_master");
        //}

        
        // GET: order_assign_master
        public ActionResult Index()
        {
           
            var order_assign_master = db.order_assign_master.Include(o => o.order_master);
           
             return View(order_assign_master.Where(f => f.cheif_type == null).Where(f=>f.order_master.status==null).ToList());
            //if (order_assign_master.Where(f => f.cheif_type == null)==null){
            //return View(db.order_master.Where(f => f.status == null).ToList());
               
            //} else
            //    return View();
            
        }

        // GET: order_assign_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_assign_master order_assign_master = db.order_assign_master.Find(id);
            if (order_assign_master == null)
            {
                return HttpNotFound();
            }
            return View(order_assign_master);
        }

        // GET: order_assign_master/Create
        public ActionResult Create()
        {
            
            ViewBag.order_master_id = new SelectList(db.order_master, "order_master_id", "order_master_id");

            return View();
        }

        // POST: order_assign_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_assign_id,order_master_id,cheif_type")] order_assign_master order_assign_master, order_master order_Master)
        {
            if (ModelState.IsValid)
            {
                db.order_assign_master.Add(order_assign_master);
                db.SaveChanges();
                //var model = new order_assign_master();
                
                //var dataitem = db.order_master.Where(m => m.order_master_id == order_Master.order_master_id).SingleOrDefault();
                //var dataitem1 = db.food_item_master.Where(m => m.food_item_id == order_Master.food_item_id).SingleOrDefault();
                //var dataitem2 = db.order_assign_master.Where(m => m.Order_assign_id == order_assign_master.Order_assign_id).FirstOrDefault();
                //model.Order_assign_id = dataitem2.order_master_id;
                //model.cheif_type = dataitem2.cheif_type;

                //if (dataitem != null)
                //{
                  // return View(dataitem);
                //}else 
               // return View(dataitem);

            }

            ViewBag.order_master_id = new SelectList(db.order_master, "order_master_id", "order_master_id", order_assign_master.order_master_id);
            return View("Index");
        }

        public ActionResult test()
        {
            return View();
        }
        public ActionResult getData()
        {
            var data = from als in db.order_assign_master select new { als.order_master.quantity, als.cheif_type };
            return Json(data.ToList(), JsonRequestBehavior.AllowGet);
        }

        public int isExisting(int id)
        {
            order_assign_master order_Assign_Master = db.order_assign_master.Find(id);
            order_master order_Master = db.order_master.Find(order_Assign_Master.order_master_id);
            List<Item> cart1 = (List<Item>)Session["cart1"];
            for (int i = 0; i < cart1.Count; i++)
                if (cart1[i].order_Masters.order_master_id == order_Master.order_master_id)
                    return i;
            return -1;
        }
        public ActionResult Reject(int id)
        {




            //  var data=db.order_assign_master.Where(f => f.Order_assign_id == id);
            //List<Item> cart = (List<Item>)Session["cart"];
            //var data = Session["cart"];
            //var s = Convert.ToInt32(data);
            //Session["regect_count"] = s- (s-1);
            if (ModelState.IsValid)
            {

                if (Session["cart1"] == null)
                {
                    Session.Remove("cart1");
                    List<Item> cart1 = new List<Item>();
                    cart1.Add(new Item(db.food_item_master.Find(id), 1));
                    Session["cart1"] = cart1;
                    order_assign_master order_Assign_Master1 = db.order_assign_master.Find(id);
                    var d = db.order_master.Where(f => f.user_id == order_Assign_Master1.order_master.user_id).FirstOrDefault();
                    if (d.user_id!=null) {
                        Session["abc"] = d.user_id;
                    Session["b"] = cart1.Count;
                    order_assign_master order_Assign_Master = db.order_assign_master.Find(id);
                    order_master order_Master = db.order_master.Find(order_Assign_Master.order_master_id);
                    order_Master.status = "order cancelled";
                    db.Entry(order_Master).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    //Session.Remove("cart");
                    return RedirectToAction("Index","order_assign_master");
                    }
                    else
                    {
                        Session["b"] = cart1.Count;
                        order_assign_master order_Assign_Master = db.order_assign_master.Find(id);
                        order_master order_Master = db.order_master.Find(order_Assign_Master.order_master_id);
                        order_Master.status = "order cancelled";
                        db.Entry(order_Master).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        //Session.Remove("cart");
                        return RedirectToAction("Index", "order_assign_master");
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
                    order_assign_master order_Assign_Master = db.order_assign_master.Find(id);
                    order_master order_Master = db.order_master.Find(order_Assign_Master.order_master_id);
                    order_Master.status = "order cancelled";
                    db.Entry(order_Master).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    //Session.Remove("cart");
                    return RedirectToAction("Index", "order_assign_master");

                }
            }
            else
            {

            }
                
               
            return View("Index");
        }

        // GET: order_assign_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_assign_master order_assign_master = db.order_assign_master.Find(id);
            if (order_assign_master == null)
            {
                return HttpNotFound();
            }
            ViewBag.order_master_id = new SelectList(db.order_master, "order_master_id", "order_master_id", order_assign_master.order_master_id);
            Session["order_master_id"] = order_assign_master.order_master_id;
            Session["food_cat_id"] = order_assign_master.order_master.food_item_master.food_category_master.food_cat_id;
            //user_master user_Master = new user_master();
            //speciality_master speciality_Master = new speciality_master();
            food_category_master food_Category_Master = new food_category_master();
            speciality_master speciality_Master = new speciality_master();
            ViewBag.speciality_id = new SelectList(db.speciality_master.Where(f => f.user_master.user_type == 3), "speciality_id", "food_Category_Master.food_cat_name", speciality_Master.food_cat_id);

            //ViewBag.cheif_type = new SelectList(db.user_master.Where(f => f.user_type == 3 && order_assign_master.order_master.food_item_master.food_category_master.food_cat_id== order_assign_master.order_master.user_master.user_id), "user_id", "first_name", order_assign_master.order_master_id);
            user_master user_Master = new user_master();

            ViewBag.cheif_type = new SelectList(db.speciality_master.Where(f => f.food_cat_id==order_assign_master.order_master.food_item_master.food_category_master.food_cat_id), "speciality_id", "user_Master.first_name", order_assign_master.order_master_id);
            //var datad= db.user_master.Where(a => a.user_id == order_assign_master.order_master.user_id).SingleOrDefault();
            //ViewBag.cheif_type = new SelectList(db.order_master.Where(a=>a.food_item_master.food_category_master.food_cat_id==speciality_Master.food_cat_id), "order_master_id", "user_Master.first_name", order_assign_master.order_master_id);
            return View(order_assign_master);
        }

        // POST: order_assign_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_assign_id,order_master_id,speciality_id,cheif_type")] order_assign_master order_assign_master)
        {
            if (ModelState.IsValid)
            {
                var data = Session["order_master_id"];
                order_assign_master.order_master_id = Convert.ToInt32(data);
                var data8 = Session["food_cat_id"];
               // var x = Convert.ToInt32(data8);
               // var data6 = db.speciality_master.Where(f => f.food_cat_id == x).FirstOrDefault();
                // var datas = db.order_assign_master.Where(s => s.order_master.food_item_id == x).FirstOrDefault();
               
                var datd=db.speciality_master.Where(a => a.speciality_id == order_assign_master.cheif_type).FirstOrDefault();
                order_assign_master.cheif_type =datd.user_id ;
                order_assign_master.reject_msg = datd.user_master.first_name;


                db.Entry(order_assign_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("save", new { id = order_assign_master.Order_assign_id });
            }
            ViewBag.order_master_id = new SelectList(db.order_master, "order_master_id", "order_master_id", order_assign_master.order_master_id);
            ViewBag.speciality_id = new SelectList(db.speciality_master.Where(f => f.user_master.user_type == 3), "speciality_id", "food_Category_Master.food_cat_name", order_assign_master.order_master_id);
            ViewBag.cheif_type = new SelectList(db.user_master.Where(f => f.user_type == 3), "user_id", "first_name", order_assign_master.order_master_id);
            return View(order_assign_master);
        }

        // GET: order_assign_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_assign_master order_assign_master = db.order_assign_master.Find(id);
            if (order_assign_master == null)
            {
                return HttpNotFound();
            }
            return View(order_assign_master);
        }

        // POST: order_assign_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order_assign_master order_assign_master = db.order_assign_master.Find(id);
            db.order_assign_master.Remove(order_assign_master);
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

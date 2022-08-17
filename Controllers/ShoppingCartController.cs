using canteen_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace canteen_management_system.Controllers
{
    public class ShoppingCartController : Controller
    {
        private canteen_manege_systemEntities13 db = new canteen_manege_systemEntities13();
        public ActionResult payment()
        {
            ViewBag.order_master_id = new SelectList(db.order_master, "order_master_id", "order_master_id");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult payment(FormCollection fc)
        {

            List<Item> cart = (List<Item>)Session["cart"];
            foreach (Item item in cart)
            {
                payment_master payment_Master = new payment_master();
                var order = Session["order_id"];
                payment_Master.order_master_id =Convert.ToInt32(order) ;
                payment_Master.payment_mode = Convert.ToInt32(fc["payment_mode"]);
                payment_Master.create_datetime = DateTime.Now;
                db.payment_master.Add(payment_Master);
                db.SaveChanges();
              
            }
            Session.Remove("cart");
            return RedirectToAction("show", "payment_master");
        }

        public ActionResult sample()
        {
            if (Session["user_id"] == null) 
            {
                return View("provide_datetimewithoutreg");
            }else
            return View("provide_datetime");
        }
        public ActionResult provide_datetime(FormCollection fc, food_item_master food_item_master) //run kakapothe change this "provide_datetime1" elaaa
        {
            if (Session["user_id"] != null)
            {
                List<Item> cart = (List<Item>)Session["cart"];
                user_master user_master = new user_master();
                foreach (Item item in cart)
                {
                    order_master order_Master = new order_master();
                    var dataitem = Session["user_id"];
                    var s = Convert.ToInt32(dataitem);
                    order_Master.user_id = s;
                    order_Master.quantity = item.Quantity;
                   // var dis1 = food_item_master.amount * food_item_master.quantity * food_item_master.discount / 100;
                    var dis = item.Food_Item_Masters.amount * item.Quantity * item.Food_Item_Masters.discount / 100;
                    order_Master.total_price = item.Food_Item_Masters.amount * item.Quantity - dis;
                    order_Master.food_item_id = item.Food_Item_Masters.food_item_id;
                    order_Master.order_date = Convert.ToDateTime(fc["order_date"]);
                    order_Master.order_deliverytime = TimeSpan.Parse(fc["order_deliverytime"]);
                    order_Master.create_date = DateTime.Now.Date;
                    order_Master.create_time = DateTime.Now.TimeOfDay;
                    db.order_master.Add(order_Master);
                    db.SaveChanges();
                    Session["order_id"] = order_Master.order_master_id;
                    order_assign_master order_Assign_Master = new order_assign_master();
                    order_Assign_Master.order_master_id = order_Master.order_master_id;
                    db.order_assign_master.Add(order_Assign_Master);
                    db.SaveChanges();
                }
                //Session.Remove("cart");
                return RedirectToAction("payment","ShoppingCart");
            }else
            return View("Checkout");
        }
        public ActionResult Inedx()
        {
            return View("Inedx");
        }
        // GET: ShoppingCart
        public ActionResult Checkout()
        {
            return View("Checkout");
        }
      
        // GET: user_master/Create
       

        // POST: user_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       
        public ActionResult savewithoutreg(FormCollection fc)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            user_master user_master = new user_master();
            foreach (Item item in cart)
            {
                order_master order_Master = new order_master();
                var dataitem = Session["user_id1"];
                var s = Convert.ToInt32(dataitem);
                order_Master.user_id = s;
                order_Master.quantity = item.Quantity;
                var dis = item.Food_Item_Masters.amount * item.Quantity * item.Food_Item_Masters.discount / 100;
                order_Master.total_price = item.Food_Item_Masters.amount * item.Quantity - dis;
                order_Master.food_item_id = item.Food_Item_Masters.food_item_id;
                order_Master.order_date = Convert.ToDateTime(fc["order_date"]);
                order_Master.order_deliverytime = TimeSpan.Parse(fc["order_deliverytime"]);
                order_Master.create_date = DateTime.Now.Date;
                order_Master.create_time = DateTime.Now.TimeOfDay;
                db.order_master.Add(order_Master);
                db.SaveChanges();
                order_assign_master order_Assign_Master = new order_assign_master();
                order_Assign_Master.order_master_id = order_Master.order_master_id;
                db.order_assign_master.Add(order_Assign_Master);
                db.SaveChanges();
                Session["order_id"] = order_Master.order_master_id;
                
            }
            //Session.Remove("cart");
            return RedirectToAction("payment","ShoppingCart");
        }

        public ActionResult Saveorder(FormCollection fc)
        {
            if (Session["user_id"] == null)
            {
                List<Item> cart = (List<Item>)Session["cart"];
                user_master user_master = new user_master();

                user_master.create_datetime = DateTime.Now;
                user_master.first_name = fc["first_name"];
                user_master.middle_name = fc["middle_name"];
                user_master.last_name = fc["last_name"];
                user_master.e_mail = fc["e_mail"];
                user_master.phone_no = fc["phone_no"];
                user_master.user_name = fc["user_name"];
                user_master.password = fc["password"];
                user_master.address = fc["address"];
                user_master.city = fc["city"];
                user_master.district = fc["district"];
                user_master.state = fc["state"];
                user_master.country = fc["country"];
                user_master.is_active = Convert.ToBoolean(fc["is_active"]);
                user_master.is_delete = Convert.ToBoolean(fc["is_delete"]);
               // user_master.update_datetime = DateTime.Now;
                user_master.pincode = Convert.ToInt32(fc["pincode"]);
                user_master.user_type = Convert.ToInt32(fc["user_type"]);
                // order_Masters.order_deliverytime = Convert.to(fc["order_deliverytime"]);
                var data = db.user_master.Where(f => f.user_name == user_master.user_name).FirstOrDefault();
               
                if (data!=null )
                {
                    Session["error1"] = "Invalid username";                  
                    return RedirectToAction("Checkout");
                    
                }
                db.user_master.Add(user_master);
                db.SaveChanges();
                Session["user_id1"] = user_master.user_id;
                Session["user_id"] = user_master.user_id;
                Session["user_withoutlogin"] = user_master.first_name;
                if (cart==null)
                {
                    var data1 = Session["f_item_id"];
                    return RedirectToAction("Create1", "rating_master",new { id=data1 });
                }
                else
                {
                    
                    return View("provide_datetimewithoutreg");
                }

            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                user_master user_master = new user_master();

                //var dataitem=Session["user_id"];
                
                //var a=Session["first_name"] ;
                //var b=Session["middle_name"];
                //var c = Session["last_name"];
                //var d = Session["e_mail"];
                //var e = Session["phone_no"] ;
                //var f = Session["user_name"] ;
                //var g = Session["password"] ;
                //var h = Session["address"];
                //var i = Session["city"] ;
                //var j = Session["district"] ;
                //var k = Session["state"];
                //var l = Session["country"] ;
                //var m = Session["pincode"];
                //var n = Session["create_datetime"];
                //var o = Session["update_datetime"] ;
                //var p = Session["is_active"] ;
                //var q = Session["is_delete"] ;
                //var r = Session["user_type"];

                //var s = Convert.ToInt32(dataitem);
                //var t = Convert.ToString(a);
                //var u = Convert.ToString(b);
                //var v = Convert.ToString(c);
                //var w = Convert.ToString(d);
                //var x = Convert.ToString(e);
                //var y = Convert.ToString(f);
                //var z = Convert.ToString(g);
                //var a1 = Convert.ToString(h);
                //var b1 = Convert.ToString(i);
                //var c1= Convert.ToString(j);
                //var d1= Convert.ToString(k);
                //var e1= Convert.ToString(l);
                //var f1= Convert.ToInt32(m);
                //var g1= Convert.ToDateTime(n);
                //var h1= Convert.ToDateTime(o);
                //var i1= Convert.ToBoolean(p);
                //var j1= Convert.ToBoolean(q);
                //var k1= Convert.ToInt32(r);

                //var data = db.user_master.Where(abc =>abc.user_id ==s).FirstOrDefault();

                //user_master.user_id = Convert.ToInt32(data.user_id);
                //user_master.first_name = Convert.ToString(data.first_name);
                //user_master.middle_name = Convert.ToString(data.middle_name);
                //user_master.last_name = Convert.ToString(data.last_name);
                //user_master.e_mail = Convert.ToString(data.e_mail);
                //user_master.phone_no = Convert.ToString(data.phone_no);
                //user_master.user_name = Convert.ToString(data.user_name);
                //user_master.password = Convert.ToString(data.password);
                //user_master.address = Convert.ToString(data.address);
                //user_master.city = Convert.ToString(data.city);
                //user_master.district = Convert.ToString(data.district);
                //user_master.state = Convert.ToString(data.state);
                //user_master.country = Convert.ToString(data.country);
                //user_master.pincode = Convert.ToInt32(data.pincode);
                //user_master.create_datetime = DateTime.Now;
                //user_master.update_datetime = DateTime.Now;
                //user_master.is_active = Convert.ToBoolean(data.is_active);
                //user_master.is_delete = Convert.ToBoolean(data.is_delete);
                //user_master.user_type = Convert.ToInt32(data.user_type);

                //db.user_master.Add(user_master);
                //db.SaveChanges();

                foreach (Item item in cart)
                {
                    order_master order_Master = new order_master();
                    var dataitem = Session["user_id"];
                    var s = Convert.ToInt32(dataitem);
                    order_Master.user_id = s;
                    order_Master.quantity = item.Quantity;
                    var dis = item.Food_Item_Masters.amount * item.Quantity * item.Food_Item_Masters.discount / 100;
                    order_Master.total_price = item.Food_Item_Masters.amount * item.Quantity - dis;
                    order_Master.food_item_id = item.Food_Item_Masters.food_item_id;
                    order_Master.order_date = DateTime.Now.Date;
                    order_Master.order_deliverytime = DateTime.Now.TimeOfDay;
                    db.order_master.Add(order_Master);
                    db.SaveChanges();
                    order_assign_master order_Assign_Master = new order_assign_master();
                    order_Assign_Master.order_master_id = order_Master.order_master_id;
                    db.order_assign_master.Add(order_Assign_Master);
                    db.SaveChanges();
                }
                Session.Remove("cart");
                return Redirect("provide_datetimewithoutreg");
            }
        }
        public int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Food_Item_Masters.food_item_id == id)
                    return i;
            return -1;
        }

        public ActionResult OrderNow(int id)
        {
            if(Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(db.food_item_master.Find(id), 1));
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExisting(id);
                if (index == -1)
                    cart.Add(new Item(db.food_item_master.Find(id), 1));
                else
                 cart[index].Quantity++;
                Session["cart"]= cart;
            }
            return View("cart");
        }

        public ActionResult Update(FormCollection fc)
        {
            string[] quantities = fc.GetValues("quantity");
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                cart[i].Quantity = Convert.ToInt32(quantities[i]);
            Session["cart"] = cart;
            return View("cart");
        }
       
        // GET: ShoppingCart/Delete/5
        public ActionResult Delete(int id)
        {
            int index = isExisting(id);
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return View("cart");
        }

        // POST: ShoppingCart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

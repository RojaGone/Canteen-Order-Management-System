using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using canteen_management_system.Models;

namespace canteen_management_system.Controllers
{
    public class food_item_masterController : Controller
    {
        private canteen_manege_systemEntities13 db = new canteen_manege_systemEntities13();

        public ActionResult Search(string searchby,string search)
        {

            return View(db.food_item_master.Where(x=>x.item_name.StartsWith(search)||search==null).Where(f => f.is_active == true).Where(f => f.is_delete == false).ToList());
        }

        // GET: food_item_master 
        public ActionResult Index()
        {
            //var food_item_master = db.food_item_master.Include(f => f.food_category_master);
            return View(db.food_item_master.Where(f=>f.is_active==true).Where(f=>f.is_delete==false).ToList());
        }

        // GET: food_item_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            food_item_master food_item_master = db.food_item_master.Find(id);
            if (food_item_master == null)
            {
                return HttpNotFound();
            }
            return View(food_item_master);
        }

        public ActionResult Details1(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            food_item_master food_item_master = db.food_item_master.Find(id);
            if (food_item_master == null)
            {
                return HttpNotFound();
            }
            return View(food_item_master);
        }


        // GET: food_item_master/Create
        public ActionResult Create()
        {
            ViewBag.food_cat__id = new SelectList(db.food_category_master, "food_cat_id", "food_cat_name");
            return View();
        }

        // POST: food_item_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(food_item_master food_Item_Master)
        {
            
            var x = 0;
            food_Item_Master.is_delete = Convert.ToBoolean(x);
            string fileName = Path.GetFileNameWithoutExtension(food_Item_Master.ImageFile.FileName);
            string extension = Path.GetExtension(food_Item_Master.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            food_Item_Master.image = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            food_Item_Master.ImageFile.SaveAs(fileName);
            using (canteen_manege_systemEntities13 db = new canteen_manege_systemEntities13())
            {
                food_Item_Master.create_datetime = DateTime.Now;
                
                db.food_item_master.Add(food_Item_Master);
                db.SaveChanges();
                ViewBag.food_cat__id = new SelectList(db.food_category_master, "food_cat_id", "food_cat_name");
            }
            ModelState.Clear();

            return RedirectToAction("Index", "food_item_master");
        }

        // GET: food_item_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            food_item_master food_item_master = db.food_item_master.Find(id);

            //var data = db.food_item_master.Where(a => a.food_cat__id == id).SingleOrDefault();
            //ViewBag.image = data.image;
            if (food_item_master == null)
            {
                return HttpNotFound();
            }
            ViewBag.food_cat__id = new SelectList(db.food_category_master, "food_cat_id", "food_cat_name", food_item_master.food_cat__id);
            return View(food_item_master);
        }

        // POST: food_item_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(food_item_master food_Item_Master)
        {
            //var x = 0;
            //food_Item_Master.is_delete = Convert.ToBoolean(x);
            string fileName = Path.GetFileNameWithoutExtension(food_Item_Master.ImageFile.FileName);
            string extension = Path.GetExtension(food_Item_Master.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            food_Item_Master.image = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            food_Item_Master.ImageFile.SaveAs(fileName);
            using (canteen_manege_systemEntities13 db = new canteen_manege_systemEntities13())
            {
                food_Item_Master.update_datetime = DateTime.Now;
                db.Entry(food_Item_Master).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.food_cat__id = new SelectList(db.food_category_master, "food_cat_id", "food_cat_name");
            }
            ModelState.Clear();

            return RedirectToAction("Index");
        }

        // GET: food_item_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            food_item_master food_item_master = db.food_item_master.Find(id);

            //var data = db.food_item_master.Where(a => a.food_cat__id == id).SingleOrDefault();
            //ViewBag.image = data.image;
            if (food_item_master == null)
            {
                return HttpNotFound();
            }
            ViewBag.food_cat__id = new SelectList(db.food_category_master, "food_cat_id", "food_cat_name", food_item_master.food_cat__id);
            return View(food_item_master);
        }

        // POST: food_item_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(food_item_master food_Item_Master,int id)
        {
            //food_item_master food_item_master = db.food_item_master.Find(id);
            //db.food_item_master.Remove(food_item_master);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            //var x = 1;
            //food_Item_Master.is_delete = Convert.ToBoolean(x);
            var data = db.food_item_master.Where(a => a.food_item_id == food_Item_Master.food_item_id).SingleOrDefault();

           
            
            food_Item_Master.item_name =data.item_name;
            food_Item_Master.item_description =data.item_description;
            food_Item_Master.amount =data.amount;
            food_Item_Master.quantity =data.quantity;
            food_Item_Master.discount =data.discount;
            food_Item_Master.image =data.image;
            food_Item_Master.create_datetime =data.create_datetime;
            food_Item_Master.food_cat__id = data.food_cat__id;
            food_Item_Master.is_active =data.is_active;
            

            //string fileName = Path.GetFileNameWithoutExtension(food_Item_Master.ImageFile.FileName);
            //string extension = Path.GetExtension(food_Item_Master.ImageFile.FileName);
            //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            //food_Item_Master.image = "~/Image/" + fileName;
            //fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            //food_Item_Master.ImageFile.SaveAs(fileName);
           
                food_Item_Master.update_datetime = DateTime.Now;
                db.Entry(food_Item_Master).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.food_cat__id = new SelectList(db.food_category_master, "food_cat_id", "food_cat_name");
            
            ModelState.Clear();

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

        public ActionResult Menu()
        {

            //return View(db.food_item_master.Where(f => f.is_active == true).Where(f => f.is_delete == false).ToList());
            ViewBag.listItems = db.food_item_master.Where(f => f.is_active == true).Where(f => f.is_delete == false).ToList();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.food_cat__id = new SelectList(db.food_category_master, "food_cat_id", "food_cat_name");
            return View();
        }

        [HttpPost]
        public ActionResult Add(food_item_master food_Item_Master)
        {
            string fileName = Path.GetFileNameWithoutExtension(food_Item_Master.ImageFile.FileName);
            string extension=Path.GetExtension(food_Item_Master.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            food_Item_Master.image = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            food_Item_Master.ImageFile.SaveAs(fileName);
            using (canteen_manege_systemEntities13 db=new canteen_manege_systemEntities13())
            {
                db.food_item_master.Add(food_Item_Master);
                db.SaveChanges();
                ViewBag.food_cat__id = new SelectList(db.food_category_master, "food_cat_id", "food_cat_name");
            }
            ModelState.Clear();
            
            return RedirectToAction("Index");
        }
        public ActionResult Ordernow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            food_item_master food_item_master = db.food_item_master.Find(id);
            if (food_item_master == null)
            {
                return HttpNotFound();
            }
            return View(food_item_master);
        }
    }
}

using canteen_management_system.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace canteen_management_system.Controllers
{
    public class food_category_masterController : Controller
    {
        private canteen_manege_systemEntities13 db = new canteen_manege_systemEntities13();
        private HttpClient webapiclient = new HttpClient();

        public food_category_masterController()
        {
            webapiclient.BaseAddress = new Uri("http://localhost:40205/api/");
        }
        // GET: food_category_master
        public ActionResult Index()
        {
            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            webapiclient.DefaultRequestHeaders.Accept.Add(contentType);
            HttpResponseMessage response = webapiclient.GetAsync("/api/food_category_master").Result;
            string responsedata = response.Content.ReadAsStringAsync().Result;
            List<Class1> catlist = JsonConvert.DeserializeObject<List<Class1>>(responsedata);
            return View(catlist.Where(f=>f.is_delete==false).ToList());
        }

        // GET: food_category_master/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage apiResponse
                   = webapiclient.GetAsync("/api/food_category_master/" + id).Result;
            string categoryData = apiResponse
                .Content.ReadAsStringAsync().Result;
            Class1 categoryToEdit
                = JsonConvert.DeserializeObject<Class1>
                (categoryData);
            return View(categoryToEdit);
        }

        // GET: food_category_master/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: food_category_master/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Class1 class1)
        {
            try
            {
                // TODO: Add insert logic here
                class1.create_datetime = DateTime.Now;
                
                class1.update_datetime = DateTime.Now;
                var x = 0;
                class1.is_delete = Convert.ToBoolean(x);
                string newCategoryData = JsonConvert.SerializeObject(class1);
                var CategoryData = new StringContent(newCategoryData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage apiResponse = webapiclient.PostAsync("/api/food_category_master", CategoryData).Result;
                ViewBag.Message = apiResponse.Content.ReadAsStringAsync().Result;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: food_category_master/Edit/5
        public ActionResult Edit(int id)
        {

             HttpResponseMessage apiResponse
                = webapiclient.GetAsync("/api/food_category_master/" + id)
                .Result;
            string employeeData = apiResponse
                .Content.ReadAsStringAsync().Result;
            Class1 employeeToEdit
                = JsonConvert.DeserializeObject<Class1>
                (employeeData);
            Session["cre_datetime"] = employeeToEdit.create_datetime;
            return View(employeeToEdit);
        }

        // POST: food_category_master/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Class1 class1)
        {
            try
            {
                class1.food_cat_id = id;
                class1.update_datetime = DateTime.Now;
                var data = Session["cre_datetime"];
                class1.create_datetime = Convert.ToDateTime(data);
                var x = 0;
                class1.is_delete = Convert.ToBoolean(x);
                // TODO: Add update logic here
                string updatedEmployeeData 
                    = JsonConvert.SerializeObject
                    (class1);
                var employeeData
                    = new StringContent(updatedEmployeeData,
                    System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response
                    = webapiclient.PutAsync("/api/food_category_master/"
                    + class1.food_cat_id, employeeData).Result;
                ViewBag.Message
                    = response.Content.ReadAsStringAsync().Result;

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: food_category_master/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage apiResponse
                    = webapiclient.GetAsync("/api/food_category_master/" + id).Result;
            string categoryData = apiResponse
                .Content.ReadAsStringAsync().Result;
            Class1 categoryToEdit
                = JsonConvert.DeserializeObject<Class1>
                (categoryData);
            return View(categoryToEdit);
        }

        // POST: food_category_master/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Class1 class1)
        {
            try
            {
                // TODO: Add delete logic here

                //HttpResponseMessage response
                //   = webapiclient.DeleteAsync("/api/food_category_master/"
                //   + id).Result;
                //ViewBag.Message
                //    = response.Content.ReadAsStringAsync().Result;

                //return RedirectToAction(nameof(Index));
                  
                class1.food_cat_id = id;
           
        var dataiitem = db.food_category_master.Where(a => a.food_cat_id == id).SingleOrDefault();
       
                class1.food_cat_name = dataiitem.food_cat_name;
               
                class1.update_datetime = DateTime.Now;
                // var data = Session["cre_datetime"];
                var set_date = dataiitem.create_datetime;
                class1.create_datetime =Convert.ToDateTime(set_date);
                var x = 1;
                class1.is_delete = Convert.ToBoolean(x);
                class1.is_active = dataiitem.is_active;
                // TODO: Add update logic here
                string updatedEmployeeData
                    = JsonConvert.SerializeObject
                    (class1);
                var employeeData
                    = new StringContent(updatedEmployeeData,
                    System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response
                    = webapiclient.PutAsync("/api/food_category_master/"
                    + class1.food_cat_id, employeeData).Result;
                ViewBag.Message
                    = response.Content.ReadAsStringAsync().Result;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

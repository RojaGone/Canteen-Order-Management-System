using canteen_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace canteen_management_system.Controllers
{
    public class loginController : Controller
    {
       // string con = @"Data Source = desktop-aeqvfrs; Initial Catalog=canteen_manege_system; Integrated Security=True";
        private canteen_manege_systemEntities13 db = new canteen_manege_systemEntities13();
              

        // GET: login/Create
       
        public ActionResult Create()
        {
            //login model = new login();
            return View();
        }

        // POST: user_master/loginCreate
        [HttpPost]
        public ActionResult Create(user_master logins, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var dataItem = db.user_master.Where(m => m.user_name == logins.user_name && m.password == logins.password)
                    .SingleOrDefault();
                if (dataItem != null)
                {

                    if (dataItem.user_type == 1)
                    {
                        Session["user_id"] = dataItem.user_id.ToString();
                        Session["user_name"] = dataItem.user_name.ToString();
                        Session["first_name"] = dataItem.first_name.ToString();
                        //var c = Session["user_id"];
                        //var v = Session["abc"];
                        //if (c == v)
                        //{
                        //    return RedirectToAction("HomeLogin", "Home");
                        //}
                        //else

                        //    return View();
                        return RedirectToAction("HomeLogin", "Home");
                    }
                    else if (dataItem.user_type == 2)
                    {

                        Session["user_id"] = dataItem.user_id.ToString();
                        Session["user_name"] = dataItem.user_name.ToString();
                        Session["first_name"] = dataItem.first_name.ToString();
                        return RedirectToAction("Index", "order_master");
                    }
                    else if (dataItem.user_type == 3)
                    {

                        Session["user_id"] = dataItem.user_id.ToString();
                        Session["user_name"] = dataItem.user_name.ToString();
                        Session["first_name"] = dataItem.first_name.ToString();
                        return RedirectToAction("Index", "chef_collect_order_master");
                    }
                }
                else
                {
                    //ViewBag.message = "Invalid username or password";
                    //return RedirectToAction("Create", "login");
                    ModelState.AddModelError(string.Empty, "Invalid username and password.......");
                }
            }
            return View();
        }


        public ActionResult logout()
        {
            Session.Remove("user_id");
            FormsAuthentication.SignOut();
            //Session.Abandon();
            return RedirectToAction("Homeindex", "Home");
        }

    }
}

using canteen_management_system.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Helpers;
using System.Web.Mvc;

namespace canteen_management_system.Controllers
{
    public class user_masterController : Controller
    {
        private canteen_manege_systemEntities13 db = new canteen_manege_systemEntities13();

        // GET: user_master
        public ActionResult Index()
        {
            return View(db.user_master.Where(f => f.is_delete == false || f.is_delete==null).ToList());
        }

        // GET: user_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_master user_master = db.user_master.Find(id);
            if (user_master == null)
            {
                return HttpNotFound();
            }
            return View(user_master);
        }

        // GET: user_master/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: user_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,first_name,middle_name,last_name,e_mail,phone_no,user_name,password,address,city,district,state,country,pincode,create_datetime,update_datetime,is_active,is_delete,user_type")] user_master user_master,FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                user_master.create_datetime = DateTime.Now;
                db.user_master.Add(user_master);
                db.SaveChanges();

                String mail = user_master.e_mail;
                String depass = user_master.password;
                ViewBag.msg = "Your Registraton is successfil. We Send Your Register Password in your Registered Email Address";


                //var fromMail = new MailAddress("lisprojectsystem@gmail.com", "LIS System"); // set your email  
                //var fromEmailpassword = "Lis@1234"; // Set your password  
                var fromMail = new MailAddress("kalpanagone4@gmail.com"); // set your email  
                var fromEmailpassword = "Kalpanagone@4"; // Set your password   
                var toEmail = new MailAddress(mail);

                var smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromMail.Address, fromEmailpassword);

                var Message = new MailMessage(fromMail, toEmail);
                Message.Subject = "Registration";
                Message.Body = "<br/> Your Registraton is successfil. We Got Your email and Password." +
                               "<br/> please Remember this Login info and Login." +
                               "<br/><br/> Email : " + mail + "<br>" + "Password :" + depass;
                Message.IsBodyHtml = true;
                smtp.Send(Message);

                //MailMessage mail = new MailMessage();
                //mail.To.Add(formCollection["e_mail"]);
                //mail.From = new MailAddress("abc12@gamil.com");
                //mail.Subject = "Registration successful.";
                //string Body = "Thanks registration your username is:" + formCollection["user_name"] + " and password is:" + formCollection["password"];
                //mail.Body = Body;
                //mail.IsBodyHtml = true;
                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com";
                //smtp.Port = 587;
                //smtp.UseDefaultCredentials = false;
                //smtp.EnableSsl = true;
                //smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                //smtp.Credentials = new System.Net.NetworkCredential("yourusername", "password");
                //smtp.Send(mail);
            }

            return View(user_master);
        }

        // GET: user_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_master user_master = db.user_master.Find(id);
            //Session["us_id"] = user_master.user_id;
            Session["fir_name"] = user_master.first_name;
            Session["middle_name"] = user_master.middle_name;
            Session["last_name"] = user_master.last_name;
            Session["e_mail"] = user_master.e_mail;
            Session["phone_no"] = user_master.phone_no;
            Session["user_name"] = user_master.user_name;
            Session["password"] = user_master.password;
            Session["address"] = user_master.address;
            Session["city"] = user_master.city;
            Session["district"] = user_master.district;
            Session["state"] = user_master.state;
            Session["country"] = user_master.country;
            Session["pincode"] = user_master.pincode;
            Session["create_datetime"] = user_master.create_datetime;
            Session["update_datetime"] = user_master.update_datetime;
            //Session["is_active"] = user_master.is_active;
            Session["user_type"] = user_master.user_type;
            if (user_master == null)
            {
                return HttpNotFound();
            }
            return View(user_master);
        }

        // POST: user_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,first_name,middle_name,last_name,e_mail,phone_no,user_name,password,address,city,district,state,country,pincode,create_datetime,update_datetime,is_active,is_delete,user_type")] user_master user_master)
        {
            if (ModelState.IsValid)
            {

                //var a = Session["us_id"];
                var b = Session["fir_name"];
                var c = Session["middle_name"];
                var d = Session["last_name"];
                var e = Session["e_mail"];
                var f = Session["phone_no"];
                var g = Session["user_name"];
                var h = Session["password"];
                var i = Session["address"];
                var j = Session["city"];
                var k = Session["district"];
                var l = Session["state"];
                var m = Session["country"];
                var n = Session["pincode"];
                var o = Session["create_datetime"];
                var p = Session["update_datetime"];
                //var q = Session["is_active"];
                var r = Session["user_type"];
                //user_master.user_id = Convert.ToInt32(a);
                user_master.first_name = Convert.ToString(b);
                user_master.middle_name = Convert.ToString(c);
                user_master.last_name = Convert.ToString(d);
                user_master.e_mail = Convert.ToString(e);
                user_master.phone_no = Convert.ToString(f);
                user_master.user_name = Convert.ToString(g);
                user_master.password = Convert.ToString(h);
                user_master.address = Convert.ToString(i);
                user_master.city = Convert.ToString(j);
                user_master.district = Convert.ToString(k);
                user_master.state = Convert.ToString(l);
                user_master.country = Convert.ToString(m);
                user_master.pincode = Convert.ToInt32(n);
                user_master.create_datetime = Convert.ToDateTime(o);
                user_master.update_datetime = DateTime.Now;
                //user_master.is_active = Convert.ToBoolean(q);
                user_master.user_type = Convert.ToInt32(r);
                db.Entry(user_master).State = EntityState.Modified;
                db.SaveChanges();
                //if (user_master.user_type == 1)
                //{
                //    return RedirectToAction("show", "Home");
                //}
                //else if (user_master.user_type == 2)
                //{
                //    return RedirectToAction("show2", "Home");
                //}
                //else if (user_master.user_type == 3)
                //{
                //    return RedirectToAction("Create", "speciality_master");
                //}
                //else
                    return RedirectToAction("Index");
            }
            return View(user_master);
        }

        // GET: user_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_master user_master = db.user_master.Find(id);
            if (user_master == null)
            {
                return HttpNotFound();
            }
            return View(user_master);
        }

        // POST: user_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user_master user_master = db.user_master.Find(id);
            db.user_master.Remove(user_master);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void SendVerificationLinkEmail(string e_mail, string activationCode ,string emailFor="VerifyAccount")
        {
            var verifyUrl = "/user_master/" + emailFor + "/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

             var fromMail = new MailAddress("kalpanagone4@gmail.com","Canteen Order Management System"); // set your email  
             var fromEmailpassword = "Kalpanagone@4"; // Set your password   
            //var fromMail = new MailAddress("parmarasmita53@gmail.com"); // set your email  
            //var fromEmailpassword = "Asmita@123";
            var toEmail = new MailAddress(e_mail);
        

            string subject = "";
            string body = "";
            if(emailFor == "VerifyAccount")
            {
                subject = "your account is successfully created!";

                body = "<br/><br/>we are excited to tell you that your Dotnet Awesome account is" +
                    "successfully created . please click on the below link to verify your account" +
                    "<br/><br/><a href='" + link + "'>" + link + "</a>";
            }
            else if(emailFor=="ResetPassword")
            {
                subject = "Reset Password";
                body = "Hi,<br/><br/>we got request for reset your account password. please click on the below link to reset your password" +
                    "<br/><br/><a href=" + link + ">Reset Password link</a>";
            }

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromMail.Address, fromEmailpassword)
            };

            using (var message = new MailMessage(fromMail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string e_mail)
        {
            string message = "";
            bool status = false;

            var account = db.user_master.Where(f => f.e_mail == e_mail).FirstOrDefault();
            if (account != null)
            {
                string resetcode = Guid.NewGuid().ToString();
                SendVerificationLinkEmail(account.e_mail, resetcode, "ResetPassword");
                account.ResetaPasswordCode = resetcode;

                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                message = "Reset password link has been sent to your email.";
            }
            else
            {
                message = "Account not found";
            }
            ViewBag.message = message;
            return View();
        }


        public ActionResult ResetPassword(string id)
        {
            var user = db.user_master.Where(f => f.ResetaPasswordCode == id).FirstOrDefault();
            if (user != null)
            {
                ResetPasswordModel model = new ResetPasswordModel();
                model.ResetCode = id;
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var user = db.user_master.Where(f => f.ResetaPasswordCode == model.ResetCode).FirstOrDefault();
                if (user != null)
                {
                    // user.password = Crypto.Hash(model.NewPassword);
                    user.password = model.NewPassword;
                    user.ResetaPasswordCode = model.NewPassword;
                    db.Entry(user).State = EntityState.Modified;
                    //db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    message = "New password update successfully";
                    ViewBag.Message = message;
                    return RedirectToAction("show");
                }
            }
            else
            {
                message = "Something invalid";
            }
            ViewBag.Message = message;
            return View(model);
        }
        public ActionResult show()
        {
            return View();
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

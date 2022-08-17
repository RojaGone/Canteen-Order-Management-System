using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using canteen_management_system.Models;
using System.Configuration;
using System.Net.Mail;
using System.Net;


namespace canteen_management_system.Controllers
{
    public class CanteenController : Controller
    {
        canteen_manege_systemEntities13 db = new canteen_manege_systemEntities13();
        string con = @"Data Source=DESKTOP-AEQVFRS;Initial Catalog=canteen_manege_system;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        // GET: Canteen
        public ActionResult Index()
        {
            DataTable dbcanteen = new DataTable();

            using(SqlConnection sqlcon=new SqlConnection(con))
            {
                sqlcon.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM user_master",sqlcon);
                sqlDataAdapter.Fill(dbcanteen);
            }
            //return View(dbcanteen);
            return View(db.user_master.Where(f=>f.is_active==true).Where(f=>f.is_delete==false).ToList());
        }

        public ActionResult View()
        {
            return View(db.user_master.Where(f => f.is_active == true).Where(f => f.is_delete == false).ToList());
        }
        // GET: Canteen/Details/5
        public ActionResult Details(int id)
        {

            CanteenModel canteenModel = new CanteenModel();
            DataTable dbcanteen = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(con))
            {
                sqlcon.Open();
                string query = "SELECT * FROM user_master Where user_id=@user_id";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlcon);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@user_id", id);
                sqlDataAdapter.Fill(dbcanteen);
            }
            if (dbcanteen.Rows.Count == 1)
            {
                canteenModel.user_id = Convert.ToInt32(dbcanteen.Rows[0][0].ToString());
                canteenModel.first_name = dbcanteen.Rows[0][1].ToString();
                canteenModel.middle_name = dbcanteen.Rows[0][2].ToString();
                canteenModel.last_name = dbcanteen.Rows[0][3].ToString();
                canteenModel.e_mail = dbcanteen.Rows[0][4].ToString();
                canteenModel.phone_no = dbcanteen.Rows[0][5].ToString();
                canteenModel.user_name = dbcanteen.Rows[0][6].ToString();
                canteenModel.password = dbcanteen.Rows[0][7].ToString();
                canteenModel.address = dbcanteen.Rows[0][8].ToString();
                canteenModel.city = dbcanteen.Rows[0][9].ToString();
                canteenModel.district = dbcanteen.Rows[0][10].ToString();
                canteenModel.state = dbcanteen.Rows[0][11].ToString();
                canteenModel.country = dbcanteen.Rows[0][12].ToString();
                canteenModel.pincode = Convert.ToInt32(dbcanteen.Rows[0][13].ToString());
                canteenModel.create_datetime = Convert.ToDateTime(dbcanteen.Rows[0][14].ToString());
                canteenModel.update_datetime = Convert.ToDateTime(dbcanteen.Rows[0][15].ToString());
                canteenModel.is_active = Convert.ToBoolean(dbcanteen.Rows[0][16].ToString());
                //canteenModel.is_active = Convert.ToInt32(dbcanteen.Rows[0][16].ToString());
                canteenModel.is_delete = Convert.ToBoolean(dbcanteen.Rows[0][17].ToString());
                //canteenModel.is_delete = Convert.ToInt32(dbcanteen.Rows[0][17].ToString());
                canteenModel.user_type = Convert.ToInt32(dbcanteen.Rows[0][18].ToString());
                return View(canteenModel);
            }
            return RedirectToAction("Index");
        }

        // GET: Canteen/RegistrationCreate
        public ActionResult Create()
        {
            return View(new CanteenModel());
        }

        // POST: Canteen/RegistrationCreate
        [HttpPost]
        public ActionResult Create(CanteenModel canteenModel)
        {
            var Message = "";
            using (SqlConnection sqlcon=new SqlConnection(con))
            {
                sqlcon.Open();
                string query = "INSERT INTO user_master(first_name,middle_name,last_name,e_mail,phone_no,user_name,password,address,city,district,state,country,pincode,user_type,create_datetime) VALUES(@first_name,@middle_name,@last_name,@e_mail,@phone_no,@user_name,@password,@address,@city,@district,@state,@country,@pincode,@user_type,@x)";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@first_name", canteenModel.first_name);
                sqlcmd.Parameters.AddWithValue("@middle_name", canteenModel.middle_name);
                sqlcmd.Parameters.AddWithValue("@last_name", canteenModel.last_name);
                sqlcmd.Parameters.AddWithValue("@e_mail", canteenModel.e_mail);
                sqlcmd.Parameters.AddWithValue("@phone_no", canteenModel.phone_no);
                sqlcmd.Parameters.AddWithValue("@user_name", canteenModel.user_name);
                sqlcmd.Parameters.AddWithValue("@password", canteenModel.password);
                sqlcmd.Parameters.AddWithValue("@address", canteenModel.address);
                sqlcmd.Parameters.AddWithValue("@city", canteenModel.city);
                sqlcmd.Parameters.AddWithValue("@district", canteenModel.district);
                sqlcmd.Parameters.AddWithValue("@state", canteenModel.state);
                sqlcmd.Parameters.AddWithValue("@country", canteenModel.country);
                sqlcmd.Parameters.AddWithValue("@pincode", canteenModel.pincode);
                
                sqlcmd.Parameters.AddWithValue("@user_type", canteenModel.user_type);
                canteenModel.create_datetime = DateTime.Now;
                var x = canteenModel.create_datetime;
                sqlcmd.Parameters.AddWithValue("@x", canteenModel.create_datetime);
                //canteenModel.password=PasswordHelper.ComputeHash()
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source = desktop-aeqvfrs; Initial Catalog=canteen_manege_system; Integrated Security=True";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select  *from [user_master]where user_name=@user_name";


                cmd.Parameters.AddWithValue("@user_name", canteenModel.user_name);

                cmd.Connection = con;
                SqlDataReader rd = cmd.ExecuteReader();
             
                if (rd.HasRows)
                {
                    ViewBag.visible = true;
                    ViewBag.text = "username is already in use";
                    ViewBag.forecolor = System.Drawing.Color.Red;
                        Session["error"] = "Invalid username";
                    return RedirectToAction("Create");
                    
                }



             
               
                

                String username = canteenModel.user_name;
                String mail = canteenModel.e_mail;
                String depass = canteenModel.password;
                ViewBag.msg = "Your Registraton is successfil. We Send Your Register Username and Password in your Registered Email Address";


                //var fromMail = new MailAddress("lisprojectsystem@gmail.com", "LIS System"); // set your email  
                //var fromEmailpassword = "Lis@1234"; // Set your password  
                var fromMail = new MailAddress("kalpanagone4@gmail.com", "Cateen Order Management System"); // set your email  
                var fromEmailpassword = "Kalpanagone@4"; // Set your password   
                                                         //var fromMail = new MailAddress("parmarasmita53@gmail.com", "Cateen Order Management System"); // set your email  
                                                         //var fromEmailpassword = "Asmita@123";
                var toEmail = new MailAddress(mail);

                var smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromMail.Address, fromEmailpassword);

                var Messages = new MailMessage(fromMail, toEmail);
                Messages.Subject = "Registration";
                Messages.Body = "<br/> Your Registraton is successful. We Got Your Username and Password." +
                               "<br/> please Remember this Login info and Login." +
                               "<br/><br/> Username : " + username + "<br>" + "Password :" + depass;
                Messages.IsBodyHtml = true;
                smtp.Send(Messages);


                sqlcmd.ExecuteNonQuery();
                Message = "Invalid user name";

                var data = db.user_master.Where(m => m.user_name == canteenModel.user_name).SingleOrDefault();
                Session["first_name"] = canteenModel.first_name;
                Session["user_id"] = data.user_id;

                if (canteenModel.user_type == 1)
                {
                    return RedirectToAction("show", "Home");
                }
                else if (canteenModel.user_type == 2)
                {
                    return RedirectToAction("show2", "Home");
                }
                else if (canteenModel.user_type == 3)
                {
                    return RedirectToAction("Create", "speciality_master");
                }
                else
                    ViewBag.message = Message;
                return RedirectToAction("Index");



                sqlcmd.ExecuteNonQuery();
                Message = "Invalid user name";
            }
            

            
        }


        // GET: Canteen/Edit/5
        public ActionResult Edit(int id)
        {
            CanteenModel canteenModel = new CanteenModel();
            DataTable dbcanteen = new DataTable();
            using(SqlConnection sqlcon=new SqlConnection(con))
            {
                sqlcon.Open();
                string query = "SELECT * FROM user_master Where user_id=@user_id";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlcon);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@user_id", id);
                sqlDataAdapter.Fill(dbcanteen);
            }
            if(dbcanteen.Rows.Count==1){
                canteenModel.user_id = Convert.ToInt32(dbcanteen.Rows[0][0].ToString());
                canteenModel.first_name = dbcanteen.Rows[0][1].ToString();
                canteenModel.middle_name = dbcanteen.Rows[0][2].ToString();
                canteenModel.last_name = dbcanteen.Rows[0][3].ToString();
                canteenModel.e_mail = dbcanteen.Rows[0][4].ToString();
                canteenModel.phone_no = dbcanteen.Rows[0][5].ToString();
                canteenModel.user_name = dbcanteen.Rows[0][6].ToString();
                canteenModel.password = dbcanteen.Rows[0][7].ToString();
                canteenModel.address = dbcanteen.Rows[0][8].ToString();
                canteenModel.city = dbcanteen.Rows[0][9].ToString();
                canteenModel.district = dbcanteen.Rows[0][10].ToString();
                canteenModel.state = dbcanteen.Rows[0][11].ToString();
                canteenModel.country = dbcanteen.Rows[0][12].ToString();
                canteenModel.pincode = Convert.ToInt32(dbcanteen.Rows[0][13].ToString());
                canteenModel.create_datetime = Convert.ToDateTime(dbcanteen.Rows[0][14].ToString());
                canteenModel.update_datetime = Convert.ToDateTime(dbcanteen.Rows[0][15].ToString());
                canteenModel.is_active = Convert.ToBoolean(dbcanteen.Rows[0][16].ToString());
                //canteenModel.is_active = Convert.ToInt32(dbcanteen.Rows[0][16].ToString());
                canteenModel.is_delete = Convert.ToBoolean(dbcanteen.Rows[0][17].ToString());
                //canteenModel.is_delete = Convert.ToInt32(dbcanteen.Rows[0][17].ToString());
                canteenModel.user_type = Convert.ToInt32(dbcanteen.Rows[0][18].ToString());
                return View(canteenModel);
            }
            if (canteenModel.user_type == 1)
            {
                return RedirectToAction("Index","Canteen");
            }
            else if (canteenModel.user_type == 2)
            {
                return RedirectToAction("Index","Canteen");
            }
            else if (canteenModel.user_type == 3)
            {
                return RedirectToAction("Create", "speciality_master");
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Canteen/Edit/5
        [HttpPost]
        public ActionResult Edit(CanteenModel canteenModel)
        {
            using (SqlConnection sqlcon = new SqlConnection(con))
            {
                sqlcon.Open();
                string query = "UPDATE user_master SET first_name=@first_name, middle_name=@middle_name, last_name=@last_name, e_mail=@e_mail, phone_no=@phone_no, user_name=@user_name, password=@password,address=@address, city=@city, district=@district, state=@state, country=@country, pincode=@pincode, create_datetime=@create_datetime, update_datetime=@update_datetime, is_active=@is_active, is_delete=@is_delete, user_type=@user_type Where user_id=@user_id";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@user_id", canteenModel.user_id);
                sqlcmd.Parameters.AddWithValue("@first_name", canteenModel.first_name);
                sqlcmd.Parameters.AddWithValue("@middle_name", canteenModel.middle_name);
                sqlcmd.Parameters.AddWithValue("@last_name", canteenModel.last_name);
                sqlcmd.Parameters.AddWithValue("@e_mail", canteenModel.e_mail);
                sqlcmd.Parameters.AddWithValue("@phone_no", canteenModel.phone_no);
                sqlcmd.Parameters.AddWithValue("@user_name", canteenModel.user_name);
                sqlcmd.Parameters.AddWithValue("@password", canteenModel.password);
                sqlcmd.Parameters.AddWithValue("@address", canteenModel.address);
                sqlcmd.Parameters.AddWithValue("@city", canteenModel.city);
                sqlcmd.Parameters.AddWithValue("@district", canteenModel.district);
                sqlcmd.Parameters.AddWithValue("@state", canteenModel.state);
                sqlcmd.Parameters.AddWithValue("@country", canteenModel.country);
                sqlcmd.Parameters.AddWithValue("@pincode", canteenModel.pincode);
                sqlcmd.Parameters.AddWithValue("@create_datetime", canteenModel.create_datetime);
                sqlcmd.Parameters.AddWithValue("@update_datetime", canteenModel.update_datetime);
                sqlcmd.Parameters.AddWithValue("@is_active", canteenModel.is_active);
                sqlcmd.Parameters.AddWithValue("@is_delete", canteenModel.is_delete);
                sqlcmd.Parameters.AddWithValue("@user_type", canteenModel.user_type);

                sqlcmd.ExecuteNonQuery();
            }

            if (canteenModel.user_type == 1)
            {
                return RedirectToAction("Index");
            }
            else if (canteenModel.user_type == 2)
            {
                return RedirectToAction("Index");
            }
            else if (canteenModel.user_type == 3)
            {
                return RedirectToAction("Create", "speciality_master");
            }
            else
                return RedirectToAction("Index");
        }

        // GET: Canteen/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlcon = new SqlConnection(con))
            {
                sqlcon.Open();
                string query = "DELETE FROM user_master Where user_id=@user_id";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@user_id",id);

                sqlcmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // POST: Canteen/Delete/5
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

     public ActionResult button_click(CanteenModel canteenModel,object sender,EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = desktop-aeqvfrs; Initial Catalog=canteen_manege_system; Integrated Security=True";
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandText = "select  *from [user_master]where user_name=@user_name";

            sqlcmd.Parameters.AddWithValue("@user_id", canteenModel.user_id);
            sqlcmd.Parameters.AddWithValue("@first_name", canteenModel.first_name);
            sqlcmd.Parameters.AddWithValue("@middle_name", canteenModel.middle_name);
            sqlcmd.Parameters.AddWithValue("@last_name", canteenModel.last_name);
            sqlcmd.Parameters.AddWithValue("@e_mail", canteenModel.e_mail);
            sqlcmd.Parameters.AddWithValue("@phone_no", canteenModel.phone_no);
            sqlcmd.Parameters.AddWithValue("@user_name", canteenModel.user_name);
            sqlcmd.Parameters.AddWithValue("@password", canteenModel.password);
            sqlcmd.Parameters.AddWithValue("@address", canteenModel.address);
            sqlcmd.Parameters.AddWithValue("@city", canteenModel.city);
            sqlcmd.Parameters.AddWithValue("@district", canteenModel.district);
            sqlcmd.Parameters.AddWithValue("@state", canteenModel.state);
            sqlcmd.Parameters.AddWithValue("@country", canteenModel.country);
            sqlcmd.Parameters.AddWithValue("@pincode", canteenModel.pincode);
            sqlcmd.Parameters.AddWithValue("@create_datetime", canteenModel.create_datetime);
            sqlcmd.Parameters.AddWithValue("@update_datetime", canteenModel.update_datetime);
            sqlcmd.Parameters.AddWithValue("@is_active", canteenModel.is_active);
            sqlcmd.Parameters.AddWithValue("@is_delete", canteenModel.is_delete);
            sqlcmd.Parameters.AddWithValue("@user_type", canteenModel.user_type);

            sqlcmd.Connection = con;
            SqlDataReader rd = sqlcmd.ExecuteReader();

            if (rd.HasRows)
            {
                 ViewBag.visible = true;
                ViewBag.text = "username is already in use";
                ViewBag.forecolor = System.Drawing.Color.Red;
                return RedirectToAction("Create");
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }


    }
}

using AutomobileServiceStation.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomobileServiceStation.Controllers
{
    
    public class ContactController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactInfo contactInfo)
        {
            SqlCommand cmd = new SqlCommand("insert into contactinfoes(Name,Email,Subject,Message) values ('" + contactInfo.Name + "','" + contactInfo.Email + "','" + contactInfo.Subject + "','" + contactInfo.Message + "')", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("Contact");
            }
            catch
            {
                return View();
            }
        }
    }
}
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
    public class PaymentController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        // GET: Payment
        public ActionResult Payment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Payment(PaymentInfo  paymentInfo)
        {
            SqlCommand cmd = new SqlCommand("insert into paymentinfoes(Name,Email,Address,City,State,Zip) values ('" + paymentInfo.Name + "','" + paymentInfo.Email + "','" + paymentInfo.Address + "','" + paymentInfo.City + "','" + paymentInfo.State + "','"+paymentInfo.Zip+"')", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("Payment");
            }
            catch
            {
                return View();
            }
            
        }
    }
}
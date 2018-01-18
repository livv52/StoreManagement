using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace StoreManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        protected void FancyBtn_Click(object sender, EventArgs e)
        {
            string CS = "data source=LIV52/SQLEXPRESS (LIV52/livia); database = Stores_db; integrated security=SSPI";
            string name = "Lego";
            using (var con = new SqlConnection(CS))
            {
                string Command = "INSERT INTO Store (Name) VALUES (@name)";
                var cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue(@name, name);
                con.Open();
                cmd.ExecuteNonQuery();
                   
            }
        }

    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Data;
using System.Data.SQLite;

namespace PiPage.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=testdb.db;Version=3;");
            conn.Open();
            string sql = "SELECT * FROM links";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);

            SQLiteDataReader reader = cmd.ExecuteReader();
            var linkResults = new List<string>();
            while (reader.Read())
                linkResults.Add(reader["link"] + reader["date"].ToString());
            //Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
            conn.Close();
            ViewBag.db = linkResults;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

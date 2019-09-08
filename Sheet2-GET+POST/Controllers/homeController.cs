using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sheet2_GET_POST.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(double amount,int years, double rate) {
            double money=0.0;
            /*Calculate total amount*/
            for (int i = 0; i < years; i++) {
                amount += amount * (rate / 100);
            }
            money = amount;
            ViewBag.total = Convert.ToDecimal(money).ToString("C");
            return View();
        }
        //when the form needs to be loaded for the first time 
        public ActionResult Grades() {
            return View("Grades");
        }
        //to collect data from the from
       [HttpPost]
        public ActionResult Grades(FormCollection gradesForm) {
            double g1 = Double.Parse(gradesForm["grade1"]);
            double g2 = Double.Parse(gradesForm["grade2"]);
            double g3 = Double.Parse(gradesForm["grade3"]);
            double avg = (g1 + g2 + g3) / 3;
            String lettergrade;
            if (avg <= 100 && avg >= 90)
            {
                lettergrade = "A";
            }
            else if (avg <= 89 && avg >= 80)
            {
                lettergrade = "B";
            }
            else if (avg <= 79 && avg >= 70)
            {
                lettergrade = "C";
            }
            else if (avg <= 69 && avg >= 60)
            {
                lettergrade = "D";
            }
            else { 
            lettergrade = "E"; }

            ViewBag.grade = lettergrade;
            return View("Grades");

        }
        
    }
}
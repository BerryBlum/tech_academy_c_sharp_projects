using carRentalApplication.Models;
using carRentalApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace carRentalApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult GetQuote(string firstName,  string lastName, string emailAddress,
            string dateOfBirth, int speedingTickets, int carYear,
            string carMake, string carModel, int insuranceCoverage = 0, int underInfluence = 0) //parse for actual date for dateofbirth from string
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(dateOfBirth))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (db_carRentalEntities db = new db_carRentalEntities())
                {
                    var carquotes = db.rentalCharts;
                    var carquoteVms = new List<CarRentalQuoteVM>();
                    foreach (var carquote in carquotes)
                    {
                        var carquoteVm = new CarRentalQuoteVM();
                        carquoteVm.FirstName = carquote.FirstName;
                        carquoteVm.LastName = carquote.LastName;
                        carquoteVm.EmailAddress = carquote.EmailAddress;
                        carquoteVm.DateOfBirth = carquote.DateOfBirth;
                        carquoteVm.UnderInfluence = carquote.UnderInfluence;
                        carquoteVm.SpeedingTickets = carquote.SpeedingTickets;
                        carquoteVm.CarMake = carquote.CarMake;
                        carquoteVm.CarModel = carquote.CarModel;
                        carquoteVm.CarYear = carquote.CarYear;
                        carquoteVm.FullCoverage = carquote.FullCoverage;
                        carquoteVm.MonthlyTotal = MonthlyTotal(carquote.Id, carquote.DateOfBirth, carquote.SpeedingTickets, carquote.CarMake, carquote.CarModel, carquote.CarYear, carquote.UnderInfluence, carquote.FullCoverage);
                        carquoteVms.Add(carquoteVm);

                        //db.rentalCharts.Add(carquoteVms);
                        //db.SaveChanges();
                    }
                    return View(carquoteVms);
                }
            }
        }
        private static decimal MonthlyTotal(int id, string dateOfBirth, int speedingTickets, string carMake,
           string carModel, int carYear, int underInfluence = 0, int fullCoverage = 0)
        {
            decimal monthlyTotal = 50;
            string birth = dateOfBirth;
            TimeSpan span = DateTime.Now - DateTime.Parse(birth);
            int age = Convert.ToInt32(span.Days / 365);


            if (16 <= age && age < 18)
            {
                monthlyTotal += 100;
            }
            else if (18 <= age && age < 25)
            {
                monthlyTotal += 25;
            }
            else if (100 <= age)
            {
                monthlyTotal += 25;
            }
            else if (age < 16)
            {
                return monthlyTotal;
            }
            if (carYear < 2000)
            {
                monthlyTotal += 25;
            }
            else if (2015 <= carYear)
            {
                monthlyTotal += 25;
            }
            monthlyTotal += speedingTickets * 10;

            if (carMake.ToLower() == "porsche")
            {
                if (carModel.ToLower() == "911 carrera")
                {
                    monthlyTotal += 25;
                }
                monthlyTotal += 25;
            }
            if (underInfluence != 0)
            {
                monthlyTotal = Convert.ToDecimal(decimal.ToDouble(monthlyTotal) * 1.25);
            }

            if (fullCoverage != 0)
            {
                monthlyTotal = Convert.ToDecimal(decimal.ToDouble(monthlyTotal) * 1.5);
            }
            return monthlyTotal;
        }
    }
}
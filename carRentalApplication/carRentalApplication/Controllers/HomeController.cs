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
                    var getQuote = new rentalChart();
                    getQuote.FirstName = firstName;
                    getQuote.LastName = lastName;
                    getQuote.EmailAddress = emailAddress;
                    getQuote.DateOfBirth = dateOfBirth;
                    getQuote.UnderInfluence = underInfluence;
                    getQuote.SpeedingTickets = speedingTickets;
                    getQuote.CarMake = carMake;
                    getQuote.CarModel = carModel;
                    getQuote.CarYear = carYear;
                    getQuote.FullCoverage = insuranceCoverage;
                    getQuote.MonthlyTotal = MonthlyTotal(getQuote.DateOfBirth, getQuote.SpeedingTickets, getQuote.CarMake, getQuote.CarModel, getQuote.CarYear, getQuote.UnderInfluence, getQuote.FullCoverage);

                    db.rentalCharts.Add(getQuote);
                    db.SaveChanges();
                    return View("GetQuote");
                }
            }
        }
        private static decimal MonthlyTotal(string dateOfBirth, int speedingTickets, string carMake,
           string carModel, int carYear, int underInfluence = 0, int fullCoverage = 0)
        {
            string birth = dateOfBirth;
            TimeSpan span = DateTime.Now - DateTime.Parse(birth);
            int age = Convert.ToInt32(span.Days / 365);
            decimal total = 50;

            if (16 <= age && age < 18)
            {
                total += 100;
            }
            else if (18 <= age && age < 25)
            {
                total += 25;
            }
            else if (100 <= age)
            {
                total += 25;
            }
            else if (age < 16)
            {
                return total;
            }
            if (carYear < 2000)
            {
                total += 25;
            }
            else if (2015 <= carYear)
            {
                total += 25;
            }
            total += speedingTickets * 10;

            if (carMake.ToLower() == "porsche")
            {
                if (carModel.ToLower() == "911 carrera")
                {
                   total += 25;
                }
                total += 25;
            }
            if (underInfluence != 0)
            {
               total = Convert.ToDecimal(decimal.ToDouble(total) * 1.25);
            }

            if (fullCoverage != 0)
            {
                total = Convert.ToDecimal(decimal.ToDouble(total) * 1.5);
            }
            return total;
        }
    }
}
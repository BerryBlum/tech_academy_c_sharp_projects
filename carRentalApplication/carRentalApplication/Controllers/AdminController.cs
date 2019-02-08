using carRentalApplication.Models;
using carRentalApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace carRentalApplication.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (db_carRentalEntities db = new db_carRentalEntities())
            {
                var carquotes = db.rentalCharts;
                var carquoteVms = new List<CarRentalQuoteVM>();
                foreach (var quote in carquotes)
                {
                    var carquoteVm = new CarRentalQuoteVM();
                    carquoteVm.FirstName = quote.FirstName;
                    carquoteVm.LastName = quote.LastName;
                    carquoteVm.EmailAddress = quote.EmailAddress;
                    carquoteVm.DateOfBirth = quote.DateOfBirth;
                    carquoteVm.UnderInfluence = quote.UnderInfluence;
                    carquoteVm.SpeedingTickets = quote.SpeedingTickets;
                    carquoteVm.CarMake = quote.CarMake;
                    carquoteVm.CarModel = quote.CarModel;
                    carquoteVm.CarYear = quote.CarYear;
                    carquoteVm.FullCoverage = quote.FullCoverage;
                    carquoteVm.MonthlyTotal = MonthlyTotal(quote.Id, quote.DateOfBirth, quote.SpeedingTickets, quote.CarMake, quote.CarModel, quote.CarYear, quote.UnderInfluence, quote.FullCoverage);
                    carquoteVms.Add(carquoteVm);
                }
                return View(carquoteVms);
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
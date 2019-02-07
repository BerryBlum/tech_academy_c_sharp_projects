using carRentalApplication.Models;
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
            string dateOfBirth, int underInfluence, int speedingTickets, int carYear,
            string carMake, string carModel, int insuranceCoverage) //parse for actual date for dateofbirth from string
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(dateOfBirth)
                || string.IsNullOrEmpty(carMake) || string.IsNullOrEmpty(carModel))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (db_carRentalEntities db = new db_carRentalEntities())
                {
                    var getquote = new GetQuote();
                    getquote.

                    db.rentalChart.Add(getquote);
                    db.SaveChanges();
                }
            }
            return View();
        }
    }
}
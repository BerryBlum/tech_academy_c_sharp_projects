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
                foreach(var quote in carquotes)
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
                    carquoteVms.Add(carquoteVm);
                }
                return View(carquoteVms);
            }
        }
    }
}
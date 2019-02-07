using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace carRentalApplication.Controllers
{
    public class MonthlyTotalController : Controller
    {
        // GET: MonthlyTotal
        public static void MonthlyTotal(int id, string dateOfBirth, int underInfluence, int speedingTickets, string carMake,
            string carModel, int carYear, bool fullCoverage)
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
                if(carModel.ToLower() == "911 carrera")
                {
                    monthlyTotal += 25;
                }
                monthlyTotal += 25;
            }
            if(underInfluence > 0)
            {
                
            }

            if (fullCoverage)
            {

            }

        }
    }
}
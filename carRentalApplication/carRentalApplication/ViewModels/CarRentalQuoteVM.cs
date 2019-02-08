using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace carRentalApplication.ViewModels
{
    public class CarRentalQuoteVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string DateOfBirth { get; set; }
        public int SpeedingTickets { get; set; }
        public int UnderInfluence { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int CarYear { get; set; }
        public int FullCoverage { get; set; }
        public decimal MonthlyTotal { get; set; }
    }
}
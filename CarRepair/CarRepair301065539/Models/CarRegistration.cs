using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRepair301065539.Models
{
    public class CarRegistration
    {
        public string LicensePlate { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Make { get; set; }
        public string Model { get; set; }
        public int AdditionalFeatures { get; set; }
        public DateTime RegistrationDate { get; } = DateTime.Now;
    }
}

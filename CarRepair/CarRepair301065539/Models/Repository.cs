using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRepair301065539.Models
{
    public static class Repository
    {
        private static List<CarRegistration> registration = new List<CarRegistration>();
        public static List<CarRegistration> Registrations => registration;

        public static void AddCarRegistration(CarRegistration newRegistration)
        {
            registration.Add(newRegistration);
        }
    }
}

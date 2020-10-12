using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRepair301065539.Models;

namespace CarRepair301065539.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult CarRegistration()
        {
            return View();
        }

        [HttpPost]
        public ViewResult CarRegistration(CarRegistration newRegistration)
        {
            if (ModelState.IsValid)
            {
                Repository.AddCarRegistration(newRegistration);
                return View("ThankYou", newRegistration);
            }
            else
            {
                return View();
            }
        }

        public ViewResult CarList()
        {
            return View(Repository.Registrations.OrderBy(car => car.Name).ToList<CarRegistration>());
        }
    }
}

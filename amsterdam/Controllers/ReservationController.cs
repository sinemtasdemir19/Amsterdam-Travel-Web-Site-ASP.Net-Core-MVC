using amsterdam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace amsterdam.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ReservationController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult HotelApply()
        {
            return View();
        }
        [HttpPost]
        public IActionResult HotelApply(Hotel hotel)
        {
            if (string.IsNullOrEmpty(hotel.Name))
            {
                ModelState.AddModelError(nameof(hotel.Name), "Name is compulsory field.");
            }
            if (string.IsNullOrEmpty(hotel.Phone))
            {
                ModelState.AddModelError(nameof(hotel.Phone), "Phone number is compulsory field.");
            }
            else
            {
                if (!hotel.Phone.Contains("+"))
                {
                    ModelState.AddModelError(nameof(hotel.Email), "Phone number is not right format.");
                }
            }
            if (string.IsNullOrEmpty(hotel.Email))
            {
                ModelState.AddModelError(nameof(hotel.Email), "Email is compulsory field.");
            }
            else
            {
                if (!hotel.Email.Contains("@"))
                {
                    ModelState.AddModelError(nameof(hotel.Email), "Email address is not right format.");
                }
            }
            if (string.IsNullOrEmpty(hotel.CheckIn))
            {
                ModelState.AddModelError(nameof(hotel.CheckIn), "CheckIn compulsory field.");
            }
            else
            {
                if (!hotel.CheckIn.Contains("/"))
                {
                    ModelState.AddModelError(nameof(hotel.CheckIn), "CheckIn is not right format.");
                }
            }
            if (string.IsNullOrEmpty(hotel.CheckOut))
            {
                ModelState.AddModelError(nameof(hotel.CheckOut), "CheckOut compulsory field.");
            }
            else
            {
                if (!hotel.CheckOut.Contains("/"))
                {
                    ModelState.AddModelError(nameof(hotel.CheckOut), "CheckOut is not right format.");
                }
            }
            if (string.IsNullOrEmpty(hotel.NumberOfPerson.ToString()))
            {
                ModelState.AddModelError(nameof(hotel.NumberOfPerson), "NumberOfPerson compulsory field.");
            }
            else
            {
                if (hotel.NumberOfPerson < 1)
                {
                    ModelState.AddModelError(nameof(hotel.NumberOfPerson), "NumberOfPerson must not be less than 1.");
                }
            }

            if (ModelState.IsValid)
            {

                _db.hotels.Add(hotel);
                _db.SaveChanges();
                return View("HotelThanks", hotel);
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public IActionResult PlaneApply()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PlaneApply(Plane plane)
        {
            if (string.IsNullOrEmpty(plane.Name))
            {
                ModelState.AddModelError(nameof(plane.Name), "Name is compulsory field.");
            }
            if (string.IsNullOrEmpty(plane.Phone))
            {
                ModelState.AddModelError(nameof(plane.Phone), "Phone number is compulsory field.");
            }
            else
            {
                if (!plane.Phone.Contains("+"))
                {
                    ModelState.AddModelError(nameof(plane.Email), "Phone number is not right format.");
                }
            }
            if (string.IsNullOrEmpty(plane.Email))
            {
                ModelState.AddModelError(nameof(plane.Email), "Email is compulsory field.");
            }
            else
            {
                if (!plane.Email.Contains("@"))
                {
                    ModelState.AddModelError(nameof(plane.Email), "Email address is not right format.");
                }
            }
            if (string.IsNullOrEmpty(plane.DeparturePlace))
            {
                ModelState.AddModelError(nameof(plane.DeparturePlace), "Departure Place is compulsory field.");
            }
            if (string.IsNullOrEmpty(plane.DepartureDate))
            {
                ModelState.AddModelError(nameof(plane.DepartureDate), "Departure Date compulsory field.");
            }
            else
            {
                if (!plane.DepartureDate.Contains("/"))
                {
                    ModelState.AddModelError(nameof(plane.DepartureDate), "Departure Date is not right format.");
                }
            }
            if (string.IsNullOrEmpty(plane.NumberOfPerson.ToString()))
            {
                ModelState.AddModelError(nameof(plane.NumberOfPerson), "NumberOfPerson compulsory field.");
            }
            else
            {
                if (plane.NumberOfPerson < 1)
                {
                    ModelState.AddModelError(nameof(plane.NumberOfPerson), "NumberOfPerson must not be less than 1.");
                }
            }

            if (ModelState.IsValid)
            {
                _db.planes.Add(plane);
                _db.SaveChanges();
                return View("PlaneThanks", plane);
            }
            else
            {
                return View();
            }
        }
        public IActionResult HotelThanks()
        {
            return View();
        }
        public IActionResult PlaneThanks()
        {
            return View();
        }
    }
}

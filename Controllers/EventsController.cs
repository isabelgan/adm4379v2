using Microsoft.AspNetCore.Mvc;
using WMN.Models;
using WMN.Services;

namespace WMN.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventRegistrationService _eventRegistrationService;

        public EventsController(EventRegistrationService eventRegistrationService)
        {
            _eventRegistrationService = eventRegistrationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(string eventName, bool registrationSuccess)
        {
            if(registrationSuccess)
            {
                ViewData["RegistrationtSuccess"] = true;
            }
            ViewData["eventName"] = eventName;
            return View();
        }

        // POST: Events/Register
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register([Bind("Id,FirstName,LastName,Email,YearOfStudy,Program")] EventRegistration eventRegistration)
        {
            if (ModelState.IsValid)
            {
                _eventRegistrationService.Create(eventRegistration);
                return RedirectToAction(nameof(Register), new { registrationSuccess = true });
            }

            return View(eventRegistration);
        }
    }
}
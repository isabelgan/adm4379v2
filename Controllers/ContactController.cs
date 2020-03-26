using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WMN.Data;
using WMN.Models;
using WMN.Services;

namespace WMN.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactService _contactService;

        public ContactController(ContactService contactService)
        {
            _contactService = contactService;
        }

        // GET: Contacts/Create
        public IActionResult Create(bool contactSuccess)
        {
            if(contactSuccess)
            {
                ViewData["ContactSuccess"] = true;
            }
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,Email,Subject,Message")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactService.Create(contact);
                return RedirectToAction(nameof(Create), new { contactSuccess = true });
            }
            return View(contact);
        }
    }
}

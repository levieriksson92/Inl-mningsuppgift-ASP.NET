using Inlämningsuppgift_ASP.NET.Services;
using Inlämningsuppgift_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inlämningsuppgift_ASP.NET.Controllers
{
    public class ContactFormController : Controller
    {
        private readonly ContactFormService _contactFormService;

        public ContactFormController(ContactFormService contactFormService)
        {
            _contactFormService = contactFormService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _contactFormService.CreateAsync(model);

                if (result.IsSuccessStatusCode)
                {
                    
                    return RedirectToAction("Success");
                }

                ModelState.AddModelError("", "Error occurred while processing the contact form.");
            }

            return View(model);
        }

        public IActionResult Success()
        {
            
            return View();
        }
    }
}

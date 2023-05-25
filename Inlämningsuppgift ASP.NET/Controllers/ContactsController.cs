using Inlämningsuppgift_ASP.NET.Services;
using Inlämningsuppgift_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inlämningsuppgift_ASP.NET.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactFormService _commentService;

        public ContactsController(ContactFormService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            //ContactFormViewModel model = new ContactFormViewModel();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _commentService.CreateAsync(model);

                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index", "Account");

                ModelState.AddModelError("", "Incorrect input");
            }

            return View(model);
        }
    }
}

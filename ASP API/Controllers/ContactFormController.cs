using ASP_API.Helpers.Repositories;
using ASP_API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        private readonly ContactFormRepository _contactFormRepository;

        public ContactFormController(ContactFormRepository contactFormRepository)
        {
            _contactFormRepository = contactFormRepository;
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddContactFormAsync(ContactForm contactForm)
        {
            var addedForm = await _contactFormRepository.AddAsync(contactForm);
            return Ok(addedForm);
        }

        [Route("all")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var allForms = await _contactFormRepository.GetAllAsync();
            return Ok(allForms);
        }
    }
}

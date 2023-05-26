using Inlämningsuppgift_ASP.NET.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace Inlämningsuppgift_ASP.NET.ViewModels
{
    public class ContactFormViewModel
    {
        [Display(Name = "Your Name")]
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; } = null!;

        [Display(Name = "Your Email")]
        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Message")]
        [Required(ErrorMessage = "Please enter a message")]
        public string ContactFormText { get; set; } = null!;


        public static implicit operator ContactFormDto(ContactFormViewModel model)
        {
            return new ContactFormDto()
            {
                Name = model.Name,
                Email = model.Email,
                ContactFormText = model.ContactFormText
            };
        }
    }
}

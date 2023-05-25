using Inlämningsuppgift_ASP.NET.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace Inlämningsuppgift_ASP.NET.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Firstname")]
        [Required(ErrorMessage = "Du måste ange ett first name")]
        [RegularExpression(@"^[a-öA-Ö]+(?:['´-][a-öA-Ö]+)*$", ErrorMessage = "Invalid firstname")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Lastname")]
        [Required(ErrorMessage = "You have to enter a last name")]
        [RegularExpression(@"^[a-öA-Ö]+(?:['´-][a-öA-Ö]+)*$", ErrorMessage = "Invalid lastname")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "You have to enter an email address")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You have to enter a password")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "Password is not safe enough")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Please confirm the password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password confirmation does not match password.")]

        public string ConfirmPassword { get; set; } = null!;


        public static implicit operator RegisterModel(RegisterViewModel model)
        {
            return new RegisterModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
            };
        }




    }
}

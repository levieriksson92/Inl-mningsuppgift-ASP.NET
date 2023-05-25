using Inlämningsuppgift_ASP.NET.ViewModels;

namespace Inlämningsuppgift_ASP.NET.Models.DTO
{
    public class LoginModel
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;


        public static implicit operator LoginViewModel(LoginModel model)
        {
            return new LoginViewModel
            {
                Email = model.Email,
                Password = model.Password,
            };
        }
    }
}

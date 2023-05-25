﻿using ASP_API.Models.Entity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ASP_API.Models.DTO
{
    public class RegisterModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;
        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "Password is too weak. Include at least one number and one special sign")]
        public string Password { get; set; } = null!;

        public static implicit operator IdentityUser(RegisterModel model)
        {
            return new IdentityUser()
            {
                UserName = model.Email,
                Email = model.Email
            };
        }

        public static implicit operator UserProfileEntity(RegisterModel model)
        {
            return new UserProfileEntity()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }


    }
}

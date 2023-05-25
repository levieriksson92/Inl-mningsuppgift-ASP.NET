using ASP_API.Helpers.Services;
using ASP_API.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP_API.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthenticationController(AuthenticationService authService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _authenticationService = authService;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (await _authenticationService.RegisterAsync(model))
                return Created("", null);

            return BadRequest();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(model);

                var token = await _authenticationService.LoginAsync(model);
                if (!string.IsNullOrEmpty(token))
                    return Ok(token);

                ModelState.AddModelError("", "Incorrect email or password");
                return Unauthorized(model);
            }
            catch
            {
                return Problem();
            }
        }

    }
}

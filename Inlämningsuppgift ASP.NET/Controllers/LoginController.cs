using Inlämningsuppgift_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text;

namespace Inlämningsuppgift_ASP.NET.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                using (var http = new HttpClient())
                {
                    try
                    {
                        var result = await http.PostAsJsonAsync("apilogin", viewModel);
                        result.EnsureSuccessStatusCode();

                        var token = await result.Content.ReadAsStringAsync();

                        HttpContext.Response.Cookies.Append("accessToken", token, new CookieOptions()
                        {
                            HttpOnly = true,
                            Secure = true,
                            Expires = DateTime.Now.AddDays(1)
                        });

                        return RedirectToAction("Index", "Products");
                    }
                    catch (HttpRequestException ex)
                    {
                        //logga/visa errorsida
                        return View("Error");
                    }
                }
            }

            return View(viewModel);
        }
    }
}


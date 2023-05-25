using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Inlämningsuppgift_ASP.NET.Controllers
{
    public class UsersController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using var http = new HttpClient();

            var token = HttpContext.Request.Cookies["accessToken"];
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = await http.GetFromJsonAsync<IEnumerable<dynamic>>("api users");

            return View();
        }
    }
}

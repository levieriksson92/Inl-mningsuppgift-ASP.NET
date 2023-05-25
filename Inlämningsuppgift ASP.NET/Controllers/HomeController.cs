using Inlämningsuppgift_ASP.NET.Services;
using Inlämningsuppgift_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inlämningsuppgift_ASP.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var featuredProducts = await _productService.GetByTagAsync("Featured");
            var newProducts = await _productService.GetByTagAsync("New");
            var popularProducts = await _productService.GetByTagAsync("Popular");

            HomeViewModel model = new HomeViewModel()
            {
                //8,8,8
                Featured = featuredProducts.Take(8),
                New = newProducts.Take(8),
                Popular = popularProducts.Take(8)
            };


            return View(model);
        }
    }
}

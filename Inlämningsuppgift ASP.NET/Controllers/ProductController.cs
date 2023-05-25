using Inlämningsuppgift_ASP.NET.Models.DTO;
using Inlämningsuppgift_ASP.NET.Services;
using Inlämningsuppgift_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Inlämningsuppgift_ASP.NET.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            CollectionViewModel collectionViewModel = new CollectionViewModel();
            collectionViewModel.Products = await _productService.GetAllAsync().ConfigureAwait(false);


            return View(collectionViewModel);
        }

        
        public async Task<IActionResult> ProductDetails(int id)
        {
            Debug.WriteLine("ProductDetails action method called with id: " + id);
            var result = await _productService.GetByIdAsync(id);

            if (result == null)
            {
                Debug.WriteLine("Product not found for id: " + id);
                return NotFound(); //hantera null
            }
            Debug.WriteLine("Product retrieved: " + result);

           
            return View(result);
            
        }
    }
}

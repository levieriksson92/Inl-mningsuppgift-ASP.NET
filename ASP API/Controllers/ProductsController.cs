using ASP_API.Helpers.Repositories;
using ASP_API.Helpers.Services;
using ASP_API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ASP_API.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class ProductController : ControllerBase
        {
            private readonly ProductRepository _productRepo;
            private readonly ProductService _productService;

            public ProductController(ProductRepository productRepo, ProductService productService)
            {
                _productRepo = productRepo;
                _productService = productService;
            }

            [Route("all")]
            [HttpGet]
            public async Task<IActionResult> GetAllAsync()
            {
                var allProducts = await _productService.GetAllAsync();
                return Ok(allProducts);
            }

            [Route("id")]
            [HttpGet]
            public async Task<IActionResult> GetByIdAsync(int id)
            {
                var product = await _productService.GetAsync(x => x.Id == id);
                return Ok(product);
            }

            [Route("tag")]
            [HttpGet]
            public async Task<IActionResult> GetByTagAsync(string tag)
            {
                try
                {
                var products = await _productService.GetAllAsync(x => x.Tag == tag);
                return Ok(products);
                }
                catch (Exception)
                {
                return BadRequest("Error: Failed to retrieve products by tag.");
            }

        }

            [Route("add")]
            [HttpPost]
            public async Task<IActionResult> AddProductAsync(ProductDto product)
            {
                var addedProduct = await _productService.CreateAsync(product);
                return Ok(addedProduct);
        }
        }
    }


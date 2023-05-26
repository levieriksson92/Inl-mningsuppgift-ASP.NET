﻿using Inlämningsuppgift_ASP.NET.Models.DTO;
using Inlämningsuppgift_ASP.NET.Services;
using Inlämningsuppgift_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Inlämningsuppgift_ASP.NET.Controllers
{
    public class AdminController : Controller
    {
        private readonly CategoryService _categoryService;
        private readonly ProductService _productService;
        private readonly AuthenticationService _auth;

        public AdminController(CategoryService categoryService, ProductService productService, AuthenticationService auth)
        {
            _categoryService = categoryService;
            _productService = productService;
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateProduct()
        {
            CreateProductViewModel model = new CreateProductViewModel()
            {
                Categories = await _categoryService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.CreateAsync(model);

                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index", "Account");

                ModelState.AddModelError("", "Incorrect input");
            }

            return View(model);
        }
    }
}

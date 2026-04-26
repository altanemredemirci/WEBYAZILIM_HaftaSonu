using _11_Fluent_Validation.Context;
using _11_Fluent_Validation.Models;
using _11_Fluent_Validation.Validators;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _11_Fluent_Validation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IValidator<Product> _validator;
        private readonly IValidator<Category> _validator2;
        private readonly DataContext _context = new DataContext();


        public HomeController(IValidator<Product> validator,IValidator<Category> validator2)
        {
            _validator = validator;
            _validator2 = validator2;
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product p)
        {
            ValidationResult result = _validator.Validate(p);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(p);
            }
            _context.Products.Add(p);
            _context.SaveChanges();
            return View();
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category c)
        {
            ValidationResult result = _validator2.Validate(c);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(c);
            }
            _context.Categories.Add(c);
            _context.SaveChanges();
            return View();
        }
    }
}

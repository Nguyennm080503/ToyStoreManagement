﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using ToyStoreService.Interface;
using ToyStoreManagement.View_Models;
using ToyStoreService.Implement;

namespace ToyStoreManagement.Pages.Toy
{
    public class DetailsModel : PageModel
    {
        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;

        [BindProperty(SupportsGet = true)]
        public int ProductId { get; set; }
        public string Message { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public DetailsModel(IProductService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }

        public Product Product { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _service.GetAllProducts == null)
            {
                return NotFound();
            }

            var product = _service.GetProductById((int)id);
            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }
    }
}

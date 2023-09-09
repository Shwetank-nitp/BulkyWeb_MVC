﻿using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext db) 
        {
            _context = db;
        }

        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Search(string searchTerm)
        {
            List<Category> categories = _context.Categories
                .Where(c => c.Name.Contains(searchTerm))
                .ToList();
            return View("Index", categories);
        }

    }
}

using BulkyWeb.Data;
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
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.CategoryOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display order must be unique");
            }
            foreach (var category in _context.Categories.ToList())
            {
                if (obj.Name != null && obj.Name.ToLower() == category.Name.ToLower())
                {
                    ModelState.AddModelError("Name", "Category Name must be unique in the existing Database");
                }
                if (obj.CategoryOrder == category.CategoryOrder)
                {
                    ModelState.AddModelError("CategoryOrder", "Category order must be unique");
                }
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View(obj);
        }

        public IActionResult GoBack()
        {
            return RedirectToAction("Index");
        }
        public IActionResult Search(string? searchTerm)
        {
            if (searchTerm != null)
            {
                List<Category> categories = _context.Categories.Where(c => c.Name.Equals(searchTerm)).ToList();
                return View("Index", categories);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (_context.Categories.Find(id) == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Category obj,int? id)
        {
            if (obj.Name == obj.CategoryOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display order must be unique");
            }
            if (ModelState.IsValid) 
            {
                Category? catDb = _context.Categories.Find(id);
                if (catDb!=null) 
                {
                    catDb.Name=obj.Name;
                    catDb.CategoryOrder = obj.CategoryOrder;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Category? catDb = _context.Categories.Find(id);
            if (catDb == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(catDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

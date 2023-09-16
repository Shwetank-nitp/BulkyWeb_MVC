using BulkyWeb.Models.Models;
using BulkyWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BulkyWeb.Controllers
{
    public class CategoryController :Controller 
    {
        private readonly IUnitOfWork repo;

        public CategoryController(IUnitOfWork repo)
        {
            this.repo=repo;
        }
        public IActionResult Index()
        {
            return View(repo.CategoryRepository.GetAll().ToList());
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
            foreach (var category in repo.CategoryRepository.GetAll())
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
                repo.CategoryRepository.Add(obj);
                repo.Save();
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
                List<Category> ser = repo.CategoryRepository.Search(u => u.Name == searchTerm).ToList();
                return View("Index", ser);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (repo.CategoryRepository.GetFirstOrDefault(u=>u.ID==id) == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.CategoryOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display order must be unique");
            }
            if (ModelState.IsValid) 
            {
                repo.CategoryRepository.Update(obj);
                repo.Save();
                TempData["Success"] = "Data Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Category? catDb = repo.CategoryRepository.GetFirstOrDefault(u => u.ID == id);
            if (catDb == null)
            {
                return NotFound();
            }
            repo.CategoryRepository.Remove(catDb);
            repo.Save();
            TempData["Success"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
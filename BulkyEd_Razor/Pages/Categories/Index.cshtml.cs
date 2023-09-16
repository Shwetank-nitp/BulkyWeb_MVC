using BulkyEd_Razor.Data;
using BulkyEd_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace BulkyEd_Razor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        public readonly ApplicationDbContent _db;
        public IndexModel(ApplicationDbContent db)
        {
            _db = db;
        }
        public List<Category> CategoryList { get;set; }
        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
        public void Search(string searchTerm)
        {
            CategoryList = _db.Categories.Where(u=>u.CategoryName==searchTerm).ToList();
        }
    }
}

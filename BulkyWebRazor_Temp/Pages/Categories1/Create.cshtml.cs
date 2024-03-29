using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories1
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //[BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["Success"] = "Category created successfully";
            return RedirectToAction("/Categories1/Index");
        }

    }
}

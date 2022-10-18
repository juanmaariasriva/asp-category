using Microsoft.AspNetCore.Mvc;
using TestBookWeb.Data;
using TestBookWeb.Models;

namespace TestBookWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _db.Categories;
            return View(categoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category cat)
        {
            if(cat.Name == null || cat.Name == "")
            {
                ModelState.AddModelError("name","No puede ser vacio");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(cat);
                _db.SaveChanges();
                TempData["success"] = "Se añadió correctamente";
                return RedirectToAction("Index", "Category");
            }
            return View(cat);
        }
        //GET
        public IActionResult Update(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category cat = _db.Categories.Find(id);
            if(cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }
        //POST
        [HttpPost]
        public IActionResult Update(Category cat)
        {
            if (cat.Name == null || cat.Name == "")
            {
                ModelState.AddModelError("name", "No puede ser vacio");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(cat);
                _db.SaveChanges();
                TempData["success"] = "Se actualizó correctamente";
                return RedirectToAction("Index", "Category");
            }
            return View(cat);
        }

        //POST
        
        public IActionResult Delete(int? id)
        {
            Category cat = _db.Categories.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(cat);
            _db.SaveChanges();
            TempData["success"] = "Se borró correctamente";
            return RedirectToAction("Index", "Category");
            
        }
    }
}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly applicationDbContext _db;
        public CategoryController(applicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objcategoryList = _db.Categories;
            return View(objcategoryList);
        }
        //Get
        public IActionResult Create()
        {
           
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name","the DisplayOrder cannot exactly mtch the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Updated Succesfully";

                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int?id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = _db.Categories.Find(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }

            return View(CategoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "the DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = _db.Categories.Find(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }

            return View(CategoryFromDb);
        }
        [HttpPost ,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int?id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["Success"] = " Category Removed Successfully";
                return RedirectToAction("Index");
            
            return View(obj);
        }
    }
}

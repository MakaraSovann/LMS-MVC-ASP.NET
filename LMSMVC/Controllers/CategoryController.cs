using Microsoft.AspNetCore.Mvc;
using LMSMVC.Models;
using LMSMVC.Services;

namespace LMSMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var categories =await _service.GetAll();

            return View("Index", categories);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Store(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View(category);
            }
            if(await _service.Create(category))
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int CategoryId)
        {
            var category = await _service.GetById(CategoryId);
            return View("Edit", category);
        }
        [HttpPost]
        public async Task<ActionResult> Update(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View(category);
            }
            if(await _service.Update(category))
            {
                return RedirectToAction("Index");
                
            }
            return View(category);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int CategoryId)
        {
            var cat =await _service.GetById(CategoryId);
            return View("Delete", cat);
        }
        [HttpPost]
        public async Task<ActionResult> Destroy(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            if(await _service.Delete(category))
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}

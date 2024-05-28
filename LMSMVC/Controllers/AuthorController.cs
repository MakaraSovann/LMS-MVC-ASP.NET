using Microsoft.AspNetCore.Mvc;
using LMSMVC.Models;
using LMSMVC.Services;

namespace LMSMVC.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _service;
        public AuthorController(IAuthorService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var authors = await _service.GetAll();
            return View("Index",authors );
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Store(Author author)
        {
            if(!ModelState.IsValid)
            {
                return View(author);
            }
            if(await _service.Create(author))
            {
                return RedirectToAction("Index");
            }
            return View(author);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int AuthorId)
        {
            var au = await _service.GetById(AuthorId);
            return View("Edit", au);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Author author)
        {
            if(!ModelState.IsValid)
            {
                return View(author);
            }
            if(await _service.Update(author))
            {
                return RedirectToAction("Index");
            }
            return View(author);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int AuthorId)
        {
            var autor = await _service.GetById(AuthorId);
            return View("Delete", autor);
        }
        [HttpPost]
        public async Task<IActionResult> Destroy(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);

            }
            if(await _service.Delete(author))
            {
                return RedirectToAction("Index");
            }
            return View(author);
        }
    }
}

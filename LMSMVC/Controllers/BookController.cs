using Microsoft.AspNetCore.Mvc;
using LMSMVC.Models;
using LMSMVC.Services;

namespace LMSMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _service;
        public BookController(IBookService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _service.GetAll();
            return View("Index",books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Store(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            if (await _service.Create(book))
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int BookId)
        {
            var au = await _service.GetById(BookId);
            return View("Edit", au);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            if (await _service.Update(book))
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int BookId)
        {
            var autor = await _service.GetById(BookId);
            return View("Delete", autor);
        }
        [HttpPost]
        public async Task<IActionResult> Destroy(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);

            }
            if (await _service.Delete(book))
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}

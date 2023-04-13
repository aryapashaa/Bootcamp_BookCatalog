using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;
[Authorize(Roles = "Admin")]
public class BookController : BaseController<Book,BookRepository,int>
{
    private readonly BookRepository _bookrepository;

    public BookController(BookRepository repository) : base(repository)
    {
        this._bookrepository = repository;
    }

    // Index
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Index()
    {
        var result = await _bookrepository.Get();
        var books = new List<Book>();

        if (result.Data != null)
        {
            books = result.Data.ToList();
        }

        return View(books);
    }

    // Details
    public async Task<IActionResult> Details(int id)
    {
        var result = await _bookrepository.Get(id);
        return View(result.Data);
    }

    // Create - GET
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    // Create - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(Book book)
    {
        if (ModelState.IsValid)
        {
            var result = await _bookrepository.Post(book);
            if (result.StatusCode == "200")
            {
                TempData["Success"] = "Data berhasil masuk";
                return RedirectToAction(nameof(Index));
            }
            else if (result.StatusCode == "409")
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
        }
        return View();
    }

    // Edit - GET
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int id)
    {
        var result = await _bookrepository.Get(id);
        return View(result.Data);
    }

    // Edit - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(Book book, int id)
    {
        if (ModelState.IsValid)
        {
            var result = await _bookrepository.Put(book, id);
            if (result.StatusCode == "200")
            {
                TempData["Success"] = "Data berhasil diedit";
                return RedirectToAction(nameof(Index));
            }
            else if (result.StatusCode == "409")
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
        }
        return View();
    }

    // Delete - GET
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _bookrepository.Get(id);
        return View(result.Data);
    }

    // Delete - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Remove(int id)
    {
        if (ModelState.IsValid)
        {
            var result = await _bookrepository.Delete(id);
            if (result.StatusCode == "200")
            {
                TempData["Success"] = "Data berhasil dihapus";
                return RedirectToAction(nameof(Index));
            }
            else if (result.StatusCode == "409")
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
        }
        return View();
    }
}

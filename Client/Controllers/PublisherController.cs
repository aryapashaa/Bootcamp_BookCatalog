using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;
[Authorize(Roles = "Admin")]
public class PublisherController : BaseController<Publisher,PublisherRepository,int>
{
    private readonly PublisherRepository _publisherrepository;

    public PublisherController(PublisherRepository repository) : base(repository)
    {
        this._publisherrepository = repository;
    }

    // Index
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Index()
    {
        var result = await _publisherrepository.Get();
        var publishers = new List<Publisher>();

        if (result.Data != null)
        {
            publishers = result.Data.ToList();
        }

        return View(publishers);
    }

    // Details
    public async Task<IActionResult> Details(int id)
    {
        var result = await _publisherrepository.Get(id);
        return View(result.Data);
    }

    // Create - GET
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    // Create - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Publisher publisher)
    {
        if (ModelState.IsValid)
        {
            var result = await _publisherrepository.Post(publisher);
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
    public async Task<IActionResult> Edit(int id)
    {
        var result = await _publisherrepository.Get(id);
        return View(result.Data);
    }

    // Edit - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Publisher publisher, int id)
    {
        if (ModelState.IsValid)
        {
            var result = await _publisherrepository.Put(publisher, id);
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
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _publisherrepository.Get(id);
        return View(result.Data);
    }

    // Delete - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int id)
    {
        if (ModelState.IsValid)
        {
            var result = await _publisherrepository.Delete(id);
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

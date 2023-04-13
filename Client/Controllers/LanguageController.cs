using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;
[Authorize(Roles = "Admin")]
public class LanguageController : BaseController<Language,LanguageRepository,int>
{
    private readonly LanguageRepository _languagerepository;

    public LanguageController(LanguageRepository repository) : base(repository)
    {
        this._languagerepository = repository;
    }

    // Index
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Index()
    {
        var result = await _languagerepository.Get();
        var languages = new List<Language>();

        if (result.Data != null)
        {
            languages = result.Data.ToList();
        }

        return View(languages);
    }

    // Details
    public async Task<IActionResult> Details(int id)
    {
        var result = await _languagerepository.Get(id);
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
    public async Task<IActionResult> Create(Language language)
    {
        if (ModelState.IsValid)
        {
            var result = await _languagerepository.Post(language);
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
        var result = await _languagerepository.Get(id);
        return View(result.Data);
    }

    // Edit - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Language language, int id)
    {
        if (ModelState.IsValid)
        {
            var result = await _languagerepository.Put(language, id);
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
        var result = await _languagerepository.Get(id);
        return View(result.Data);
    }

    // Delete - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int id)
    {
        if (ModelState.IsValid)
        {
            var result = await _languagerepository.Delete(id);
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

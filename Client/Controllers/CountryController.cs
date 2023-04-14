using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;
[Authorize(Roles = "Admin")]
public class CountryController : BaseController<Country,CountryRepository,int>
{
    private readonly CountryRepository _countryrepository;

    public CountryController(CountryRepository repository) : base(repository)
    {
        this._countryrepository = repository;
    }

    // Index
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Index()
    {
        var result = await _countryrepository.Get();
        var countries = new List<Country>();

        if (result.Data != null)
        {
            countries = result.Data.ToList();
        }

        return View(countries);
    }

    // Details
    public async Task<IActionResult> Details(int id)
    {
        var result = await _countryrepository.Get(id);
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
    public async Task<IActionResult> Create(Country country)
    {
        if (ModelState.IsValid)
        {
            var result = await _countryrepository.Post(country);
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
        var result = await _countryrepository.Get(id);
        return View(result.Data);
    }

    // Edit - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Country country, int id)
    {
        if (ModelState.IsValid)
        {
            var result = await _countryrepository.Put(country, id);
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
        var result = await _countryrepository.Get(id);
        return View(result.Data);
    }

    // Delete - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int id)
    {
        if (ModelState.IsValid)
        {
            var result = await _countryrepository.Delete(id);
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

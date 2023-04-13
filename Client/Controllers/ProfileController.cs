using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;
[Authorize(Roles = "Admin")]
public class ProfileController : BaseController<Profile,ProfileRepository,int>
{
    private readonly ProfileRepository _profilerepository;

    public ProfileController(ProfileRepository repository) : base(repository)
    {
        this._profilerepository = repository;
    }

    // Index
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Index()
    {
        var result = await _profilerepository.Get();
        var profiles = new List<Profile>();

        if (result.Data != null)
        {
            profiles = result.Data.ToList();
        }

        return View(profiles);
    }

    // Details
    public async Task<IActionResult> Details(int id)
    {
        var result = await _profilerepository.Get(id);
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
    public async Task<IActionResult> Create(Profile profile)
    {
        if (ModelState.IsValid)
        {
            var result = await _profilerepository.Post(profile);
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
        var result = await _profilerepository.Get(id);
        return View(result.Data);
    }

    // Edit - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Profile profile, int id)
    {
        if (ModelState.IsValid)
        {
            var result = await _profilerepository.Put(profile, id);
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
        var result = await _profilerepository.Get(id);
        return View(result.Data);
    }

    // Delete - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int id)
    {
        if (ModelState.IsValid)
        {
            var result = await _profilerepository.Delete(id);
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

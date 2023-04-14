using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Client.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class AccountController : BaseController<Account,AccountRepository,int>
{
    private readonly AccountRepository _accountrepository;

    public AccountController(AccountRepository repository) : base(repository)
    {
        this._accountrepository = repository;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterVM registerVM)
    {
        var result = await _accountrepository.Register(registerVM);
        if (result.StatusCode == "200")
        {
			TempData["msg_register"] = "<script>alert('Register succesfully');</script>";
			return RedirectToAction("Index","Home");
        }
        return View();
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVM loginVM)
    {
        var result = await _accountrepository.Login(loginVM);
        if (result is null)
        {
            return RedirectToAction("Error", "Home");
        }
        else if (result.StatusCode == "409")
        {
            ModelState.AddModelError(string.Empty, result.Message);
            return View();
        }
        else if (result.StatusCode == "200")
        {
            HttpContext.Session.SetString("JWToken", result.Data);
			TempData["msg_login"] = "<script>alert('Login succesfully');</script>";
			return RedirectToAction("Index", "Home");
        }
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction(nameof(Index), "Home");
    }
}

using BookCatalog_API.Base;
using BookCatalog_API.Models;
using BookCatalog_API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog_API.Controllers;
[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Admin")]
public class CountriesController : BaseController<int, Country, CountryRepository>
{
    public CountriesController(CountryRepository repository) : base(repository)
    {
    }
}

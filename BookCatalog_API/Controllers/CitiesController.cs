using BookCatalog_API.Base;
using BookCatalog_API.Models;
using BookCatalog_API.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CitiesController : BaseController<int, City, CityRepository>
{
    public CitiesController(CityRepository repository) : base(repository)
    {
    }
}

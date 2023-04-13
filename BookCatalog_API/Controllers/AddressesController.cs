using BookCatalog_API.Base;
using BookCatalog_API.Models;
using BookCatalog_API.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AddressesController : BaseController<int, Address, AddressRepository>
{
    public AddressesController(AddressRepository repository) : base(repository)
    {
    }
}

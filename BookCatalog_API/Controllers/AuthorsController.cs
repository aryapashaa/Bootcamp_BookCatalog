using BookCatalog_API.Base;
using BookCatalog_API.Models;
using BookCatalog_API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : BaseController<int, Author, AuthorRepository>
{
    public AuthorsController(AuthorRepository repository) : base(repository)
    {
    }
}

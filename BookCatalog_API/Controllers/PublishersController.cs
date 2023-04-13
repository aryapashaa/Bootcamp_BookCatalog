using BookCatalog_API.Base;
using BookCatalog_API.Models;
using BookCatalog_API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublishersController : BaseController<int, Publisher, PublisherRepository>
{
    public PublishersController(PublisherRepository repository) : base(repository)
    {
    }
}

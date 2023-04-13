using BookCatalog_API.Base;
using BookCatalog_API.Models;
using BookCatalog_API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountRolesController : BaseController<int, AccountRole, AccountRoleRepository>
{
    public AccountRolesController(AccountRoleRepository repository) : base(repository)
    {
    }
}

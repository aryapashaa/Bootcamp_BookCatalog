using BookCatalog_API.Contexts;
using BookCatalog_API.Models;
using BookCatalog_API.Repositories;

namespace BookCatalog_API.Repositories.Data;

public class AccountRoleRepository : GeneralRepository<int, AccountRole>
{
    public AccountRoleRepository(MyContext context) : base(context)
    {
    }
}

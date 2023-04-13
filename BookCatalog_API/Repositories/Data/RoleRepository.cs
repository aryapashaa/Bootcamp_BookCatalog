using BookCatalog_API.Contexts;
using BookCatalog_API.Models;
using BookCatalog_API.Repositories;

namespace BookCatalog_API.Repositories.Data;

public class RoleRepository : GeneralRepository<int, Role>
{
    public RoleRepository(MyContext context) : base(context)
    {
    }
}

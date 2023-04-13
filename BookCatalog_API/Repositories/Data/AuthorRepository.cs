using BookCatalog_API.Contexts;
using BookCatalog_API.Models;
using BookCatalog_API.Repositories;

namespace BookCatalog_API.Repositories.Data;

public class AuthorRepository : GeneralRepository<int, Author>
{
    public AuthorRepository(MyContext context) : base(context)
    {
    }
}

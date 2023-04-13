using BookCatalog_API.Repositories;
using BookCatalog_API.Contexts;
using BookCatalog_API.Models;

namespace BookCatalog_API.Repositories.Data;

public class LanguageRepository : GeneralRepository<int, Language>
{
    public LanguageRepository(MyContext context) : base(context)
    {
    }
}

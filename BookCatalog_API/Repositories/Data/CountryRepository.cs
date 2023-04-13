using BookCatalog_API.Contexts;
using BookCatalog_API.Models;
using BookCatalog_API.Repositories;

namespace BookCatalog_API.Repositories.Data;

public class CountryRepository : GeneralRepository<int, Country>
{
    public CountryRepository(MyContext context) : base(context)
    {
    }
}

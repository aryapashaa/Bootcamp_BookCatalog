using BookCatalog_API.Contexts;
using BookCatalog_API.Models;

namespace BookCatalog_API.Repositories.Data;

public class CityRepository : GeneralRepository<int, City>
{
    public CityRepository(MyContext context) : base(context)
    {
    }
}

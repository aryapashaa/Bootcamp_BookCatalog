using BookCatalog_API.Repositories;
using BookCatalog_API.Contexts;
using BookCatalog_API.Models;

namespace BookCatalog_API.Repositories.Data;

public class AddressRepository : GeneralRepository<int, Address>
{
    public AddressRepository(MyContext context) : base(context)
    {
    }
}

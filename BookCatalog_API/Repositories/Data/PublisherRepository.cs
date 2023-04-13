using BookCatalog_API.Contexts;
using BookCatalog_API.Models;
using BookCatalog_API.Repositories;

namespace BookCatalog_API.Repositories.Data;

public class PublisherRepository : GeneralRepository<int, Publisher>
{
    public PublisherRepository(MyContext context) : base(context)
    {
    }
}

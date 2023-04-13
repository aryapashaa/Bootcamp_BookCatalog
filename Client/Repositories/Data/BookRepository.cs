using Client.Models;

namespace Client.Repositories.Data;

public class BookRepository : GeneralRepository<Book, int>
{

    public BookRepository(string request = "Books/") : base(request)
    {
    }
}

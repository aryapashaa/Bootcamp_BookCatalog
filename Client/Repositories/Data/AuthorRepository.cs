using Client.Models;

namespace Client.Repositories.Data;

public class AuthorRepository : GeneralRepository<Author, int>
{
    public AuthorRepository(string request = "Authors/") : base(request)
    {
    }
}

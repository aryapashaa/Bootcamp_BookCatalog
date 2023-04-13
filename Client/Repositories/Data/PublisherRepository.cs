using Client.Models;

namespace Client.Repositories.Data;

public class PublisherRepository : GeneralRepository<Publisher, int>
{

    public PublisherRepository(string request = "Publishers/") : base(request)
    {
    }
}

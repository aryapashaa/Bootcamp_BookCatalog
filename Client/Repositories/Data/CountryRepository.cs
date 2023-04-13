using Client.Models;

namespace Client.Repositories.Data;

public class CountryRepository : GeneralRepository<Country, int>
{
    public CountryRepository(string request = "Countries/") : base(request)
    {
    }
}

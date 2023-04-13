using Client.Models;

namespace Client.Repositories.Data;

public class CityRepository : GeneralRepository<City, int>
{
    public CityRepository(string request = "Cities/") : base(request)
    {
    }
}

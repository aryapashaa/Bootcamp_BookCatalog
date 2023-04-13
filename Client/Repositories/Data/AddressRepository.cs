using Client.Models;

namespace Client.Repositories.Data;

public class AddressRepository : GeneralRepository<Address, int>
{
    public AddressRepository(string request = "Addresses/") : base(request)
    {
    }
}

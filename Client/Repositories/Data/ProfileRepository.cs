using Client.Models;

namespace Client.Repositories.Data;

public class ProfileRepository : GeneralRepository<Profile, int>
{
    public ProfileRepository(string request = "Profiles/") : base(request)
    {
    }
}

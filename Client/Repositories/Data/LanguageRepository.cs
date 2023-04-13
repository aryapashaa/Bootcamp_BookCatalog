using Client.Models;

namespace Client.Repositories.Data;

public class LanguageRepository : GeneralRepository<Language, int>
{
    public LanguageRepository(string request = "Languages/") : base(request)
    {
    }
}

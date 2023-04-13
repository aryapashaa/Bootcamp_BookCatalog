using Microsoft.EntityFrameworkCore;
using BookCatalog_API.Models;
using BookCatalog_API.Repositories;
using BookCatalog_API.ViewModels;
using BookCatalog_API.Contexts;
using BookCatalog_API.Handlers;

namespace BookCatalog_API.Repositories.Data;

public class AccountRepository : GeneralRepository<int, Account>
{
    private readonly MyContext context;

    public AccountRepository(MyContext context) : base(context)
    {
        this.context = context;
    }

    public async Task<int> Register(RegisterVM registerVM)
    {
        int result = 0;
        Country country = new Country
        {
            Name = registerVM.CountryName
        };
        if (await context.Countries.AnyAsync(c => c.Name == country.Name))
        {
            country.Id = context.Countries.FirstOrDefault(c => c.Name == country.Name).Id;
        }
        else
        {
            await context.Countries.AddAsync(country);
            result = await context.SaveChangesAsync();
        }

        City city = new City
        {
            Name = registerVM.CityName,
            CountryId = country.Id
        };
        if (await context.Cities.AnyAsync(c => c.Name == city.Name))
        {
            city.Id = context.Cities.FirstOrDefault(c => c.Name == city.Name).Id;
        }
        else
        {
            await context.Cities.AddAsync(city);
            result = await context.SaveChangesAsync();
        }

        Address address = new Address
        {
            Name = registerVM.AddressName,
            PostalCode = registerVM.PostalCode,
            CityId = city.Id,
        };
        await context.Addresses.AddAsync(address);
        result = await context.SaveChangesAsync();

        Profile profile = new Profile
        {
            FirstName = registerVM.FirstName,
            LastName = registerVM.LastName,
            Email = registerVM.Email,
            BirthDate = registerVM.BirthDate,
            Gender = registerVM.Gender,
            Phone = registerVM.Phone,
            AddressId = address.Id,
        };
        await context.Profiles.AddAsync(profile);
        result = await context.SaveChangesAsync();

        Account account = new Account
        {
            ProfileId = profile.Id,
            Password = Hashing.HashPassword(registerVM.Password),
        };
        await context.Accounts.AddAsync(account);
        result = await context.SaveChangesAsync();

        AccountRole accountRole = new AccountRole
        {
            AccountId = account.ProfileId,
            RoleId = 2
        };
        await context.AccountRoles.AddAsync(accountRole);
        result = await context.SaveChangesAsync();

        return result;
    }
    public async Task<bool> Login(LoginVM loginVM)
    {
        var getAccount = await context.Profiles
            .Include(s => s.Account)
            .Select(s => new LoginVM
            {
                Email = s.Email,
                Password = s.Account.Password
            }).SingleOrDefaultAsync(a => a.Email == loginVM.Email);

        if (getAccount is null)
        {
            return false;
        }

        return Hashing.ValidatePassword(loginVM.Password, getAccount.Password);
    }
    public async Task<UserdataVM> GetUserdata(string email)
    {
        var userdata = await (from u in context.Profiles
                              join a in context.Accounts
                              on u.Id equals a.ProfileId
                              join ar in context.AccountRoles
                              on a.ProfileId equals ar.AccountId
                              join r in context.Roles
                              on ar.RoleId equals r.Id
                              where u.Email == email
                              select new UserdataVM
                              {
                                  Email = u.Email,
                                  FullName = string.Concat(u.FirstName, " ", u.LastName)
                              }).FirstOrDefaultAsync();

        return userdata;
    }
    public async Task<IEnumerable<string>> GetRolesById(string email)
    {
        var getUserId = await context.Profiles.FirstOrDefaultAsync(u => u.Email == email);
        return await context.AccountRoles.Where(ar => ar.AccountId == getUserId.Id).Join(
            context.Roles,
            ar => ar.RoleId,
            r => r.Id,
            (ar, r) => r.Name).ToListAsync();
    }
}

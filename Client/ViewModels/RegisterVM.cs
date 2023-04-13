using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Client.Models;

namespace Client.ViewModels;

public class RegisterVM
{
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderEnum Gender { get; set; }
    [Phone]
    public string Phone { get; set; }
    public string AddressName { get; set; }
    public string PostalCode { get; set; }
    public string CityName { get; set; }
    public string CountryName { get; set; }
    [DataType(DataType.Password)]
    [StringLength(255, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    public string Password { get; set; }
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace Client.Models;
public class Profile
{
    public int Id { get; set; }
	[Display(Name = "First Name")]
	public string FirstName { get; set; }
	[Display(Name = "Last Name")]
	public string? LastName { get; set; }
	[Display(Name = "E-Mail")]
	public string Email { get; set; }
	[Display(Name = "Birth Date")]
	public DateTime BirthDate { get; set; }
    public GenderEnum Gender { get; set; }
    public string Phone { get; set; }
    public int AddressId { get; set; }
}
public enum GenderEnum
{
    Male,
    Female
}
namespace Client.Models;
public class Profile
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }
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
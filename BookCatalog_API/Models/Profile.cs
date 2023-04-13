using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text.Json.Serialization;

namespace BookCatalog_API.Models;
[Table("tb_m_profiles")]
public class Profile
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("first_name"), MaxLength(50)]
    public string FirstName { get; set; }
    [Column("last_name"), MaxLength(50)]
    public string? LastName { get; set; }
    [Required, Column("email"), MaxLength(50)]
    public string Email { get; set; }
    [Required, Column("birth_date")]
    public DateTime BirthDate { get; set; }
    [Required, Column("gender")]
    public GenderEnum Gender { get; set; }
    [Required, Column("phone"), MaxLength(20)]
    public string Phone { get; set; }
    [Required, Column("address_id")]
    public int AddressId { get; set; }

    // Cardinality
    [JsonIgnore]
    [ForeignKey(nameof(AddressId))]
    public Address? Address { get; set; }
    [JsonIgnore]
    public Account? Account { get; set; }
}
public enum GenderEnum
{
    Male,
    Female
}
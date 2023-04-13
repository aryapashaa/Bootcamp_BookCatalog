using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookCatalog_API.Models;
[Table("tb_m_addresses")]
public class Address
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("name"), MaxLength(255)]
    public string Name { get; set; }
    [Required, Column("postal_code"), MaxLength(10)]
    public string PostalCode { get; set; }
    [Required, Column("city_id")]
    public int CityId { get; set; }

    // Cardinality
    [JsonIgnore]
    [ForeignKey(nameof(CityId))]
    public City? City { get; set; }
    [JsonIgnore]
    public ICollection<Profile>? Profiles { get; set; }
}

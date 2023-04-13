using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookCatalog_API.Models;
[Table("tb_m_cities")]
public class City
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("name"), MaxLength(50)]
    public string Name { get; set; }
    [Required, Column("country_id")]
    public int CountryId { get; set; }

    // Cardinality
    [JsonIgnore]
    public ICollection<Address>? Addresses { get; set; }
    [JsonIgnore]
    [ForeignKey(nameof(CountryId))]
    public Country? Country { get; set; }
}

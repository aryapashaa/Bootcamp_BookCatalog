using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookCatalog_API.Models;
[Table("tb_m_countries")]
public class Country
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("name"), MaxLength(50)]
    public string Name { get; set; }

    // Cardinality
    [JsonIgnore]
    public ICollection<City>? Cities { get; set; }
}

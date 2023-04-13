using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookCatalog_API.Models;
[Table("tb_m_languages")]
public class Language
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("name"), MaxLength(20)]
    public string Name { get; set; }

    // Cardinality
    [JsonIgnore]
    public ICollection<Book>? Books { get; set; }
}

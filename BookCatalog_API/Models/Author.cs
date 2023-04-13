using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookCatalog_API.Models;
[Table("tb_m_authors")]
public class Author
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("name"), MaxLength(50)]
    public string Name { get; set; }

    // Cardinality
    [JsonIgnore]
    public ICollection<Book>? Books { get; set; }
}

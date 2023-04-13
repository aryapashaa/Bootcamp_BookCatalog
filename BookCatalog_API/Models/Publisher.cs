using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookCatalog_API.Models;
[Table("tb_m_publishers")]
public class Publisher
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("name"), MaxLength(50)]
    public string Name { get; set; }
    [Column("phone"), MaxLength(20)]
    public string? Phone { get; set; }
    [Column("url"), MaxLength(255)]
    public string? Url { get; set; }

    // Cardinality
    [JsonIgnore]
    public ICollection<Book>? Books { get; set; }
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookCatalog_API.Models;

[Table("tb_m_accounts")]
public class Account
{
    [Key, Column("id")]
    public int ProfileId { get; set; }
    [Required, Column("password"), MaxLength(255)]
    public string Password { get; set; }

    // Cardinality
    [JsonIgnore]
    public ICollection<AccountRole>? AccountRoles { get; set; }
    [JsonIgnore]
    public Profile? Profile { get; set; }
}

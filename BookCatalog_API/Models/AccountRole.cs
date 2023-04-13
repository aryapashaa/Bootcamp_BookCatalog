using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookCatalog_API.Models;

[Table("tb_tr_accountroles")]
public class AccountRole
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("account_id")]
    public int AccountId { get; set; }
    [Required, Column("role_id")]
    public int RoleId { get; set; }

    // Cardinality
    [JsonIgnore]
    [ForeignKey(nameof(AccountId))]
    public Account? Account { get; set; }
    [JsonIgnore]
    [ForeignKey(nameof(RoleId))]
    public Role? Role { get; set; }
}

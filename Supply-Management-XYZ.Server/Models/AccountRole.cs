using System.ComponentModel.DataAnnotations.Schema;

namespace Supply_Management_XYZ.Server.Models;

[Table("tb_tr_account_roles")]
public class AccountRole : BaseEntity
{
    [Column("account_guid", TypeName = "CHAR(36)")]
    public Guid AccountGuid { get; set; }

    [Column("role_guid", TypeName = "CHAR(36)")]
    public Guid RoleGuid { get; set; }

    // Cardinality
    public Account? Account { get; set; }
    public Role? Role { get; set; }
}

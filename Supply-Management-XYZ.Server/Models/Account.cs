using System.ComponentModel.DataAnnotations.Schema;

namespace Supply_Management_XYZ.Server.Models;

[Table("tb_m_accounts")]
public class Account : BaseEntity
{
    [Column("password", TypeName = "nvarchar(255)")]
    public string Password { get; set; }

    // Cardinality
    public Employee? Employee { get; set; }
    public ICollection<AccountRole>? AccountRoles { get; set; }
    public Vendor? Vendor { get; set; }
}

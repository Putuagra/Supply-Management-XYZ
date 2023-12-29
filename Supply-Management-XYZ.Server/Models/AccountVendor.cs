using System.ComponentModel.DataAnnotations.Schema;

namespace Supply_Management_XYZ.Server.Models;

[Table("tb_m_account_vendors")]
public class AccountVendor : BaseEntity
{
    [Column("password", TypeName = "nvarchar(255)")]
    public string Password { get; set; }

    // Cardinality
    public Vendor? Vendor { get; set; }
}
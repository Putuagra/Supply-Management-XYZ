using System.ComponentModel.DataAnnotations.Schema;

namespace Supply_Management_XYZ.Server.Models;

[Table("tb_m_vendors")]
public class Vendor : BaseEntity
{
    [Column("vendor_name", TypeName = "nvarchar(255)")]
    public string Name { get; set; }
    [Column("email", TypeName = "nvarchar(100)")]
    public string Email { get; set; }
    [Column("phone_number", TypeName = "nvarchar(20)")]
    public string PhoneNumber { get; set; }
    [Column("photo_profile", TypeName = "nvarchar(255)")]
    public string PhotoProfile { get; set; }
    [Column("sector", TypeName = "nvarchar(100)")]
    public string Sector { get; set; }
    [Column("type", TypeName = "nvarchar(100)")]
    public string Type { get; set; }
    [Column("is_admin_approve")]
    public bool IsAdminApprove { get; set; }
    [Column("is_manager_approve")]
    public bool IsManagerApprove { get; set; }

    // Cardinality
    public AccountVendor? AccountVendor { get; set; }
    public ICollection<Project>? Projects { get; set; }
}

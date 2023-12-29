using System.ComponentModel.DataAnnotations.Schema;

namespace Supply_Management_XYZ.Server.Models;

[Table("tb_m_employees")]
public class Employee : BaseEntity
{
    [Column("first_name", TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }
    [Column("last_name", TypeName = "nvarchar(100)")]
    public string? LastName { get; set; }
    [Column("email", TypeName = "nvarchar(50)")]
    public string Email { get; set; }

    // Cardinality
    public Account? Account { get; set; }
}

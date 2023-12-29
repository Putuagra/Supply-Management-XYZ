using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.DataTransferObjects.AccountRoles;

public class AccountRoleDtoCreate
{
    public Guid AccountGuid { get; set; }
    public Guid RoleGuid { get; set; }

    public static implicit operator AccountRole(AccountRoleDtoCreate accountRoleDtoCreate)
    {
        return new()
        {
            AccountGuid = accountRoleDtoCreate.AccountGuid,
            RoleGuid = accountRoleDtoCreate.RoleGuid,
            CreatedDate = DateTime.UtcNow
        };
    }

    public static explicit operator AccountRoleDtoCreate(AccountRole accountRole)
    {
        return new()
        {
            AccountGuid = accountRole.AccountGuid,
            RoleGuid = accountRole.RoleGuid
        };
    }
}

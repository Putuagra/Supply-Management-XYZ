using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.DataTransferObjects.AccountRoles;

public class AccountRoleDtoUpdate
{
    public Guid Guid { get; set; }
    public Guid AccountGuid { get; set; }
    public Guid RoleGuid { get; set; }

    public static implicit operator AccountRole(AccountRoleDtoUpdate accountRoleDtoUpdate)
    {
        return new()
        {
            Guid = accountRoleDtoUpdate.Guid,
            AccountGuid = accountRoleDtoUpdate.AccountGuid,
            RoleGuid = accountRoleDtoUpdate.RoleGuid,
            ModifiedDate = DateTime.UtcNow
        };
    }

    public static explicit operator AccountRoleDtoUpdate(AccountRole accountRole)
    {
        return new()
        {
            Guid = accountRole.Guid,
            AccountGuid = accountRole.AccountGuid,
            RoleGuid = accountRole.RoleGuid
        };
    }
}

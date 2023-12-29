using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.DataTransferObjects.Roles;

public class RoleDtoCreate
{
    public string Name { get; set; }

    public static implicit operator Role(RoleDtoCreate roleDtoCreate)
    {
        return new()
        {
            Name = roleDtoCreate.Name
        };
    }

    public static explicit operator RoleDtoCreate(Role role)
    {
        return new()
        {
            Name = role.Name,
        };
    }
}

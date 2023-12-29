﻿using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.DataTransferObjects.Roles;

public class RoleDtoUpdate
{
    public Guid Guid { get; set; }
    public string Name { get; set; }

    public static implicit operator Role(RoleDtoUpdate roleDtoUpdate)
    {
        return new()
        {
            Guid = roleDtoUpdate.Guid,
            Name = roleDtoUpdate.Name
        };
    }

    public static explicit operator RoleDtoUpdate(Role role)
    {
        return new()
        {
            Guid = role.Guid,
            Name = role.Name
        };
    }
}

﻿using Supply_Management_XYZ.Server.Contracts;
using Supply_Management_XYZ.Server.DataTransferObjects.Roles;

namespace Supply_Management_XYZ.Server.Services;

public class RoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public IEnumerable<RoleDtoGet> Get()
    {
        var roles = _roleRepository.GetAll().ToList();
        if (!roles.Any()) return Enumerable.Empty<RoleDtoGet>();
        List<RoleDtoGet> roleDtoGets = new List<RoleDtoGet>();
        foreach (var role in roles)
        {
            roleDtoGets.Add((RoleDtoGet)role);
        }
        return roleDtoGets;
    }

    public RoleDtoGet? Get(Guid guid)
    {
        var role = _roleRepository.GetByGuid(guid);
        if (role is null) return null;
        return (RoleDtoGet)role;
    }

    public RoleDtoCreate? Create(RoleDtoCreate roleDtoCreate)
    {
        var roleCreated = _roleRepository.Create(roleDtoCreate);
        if (roleCreated is null) return null;
        return (RoleDtoCreate)roleCreated;
    }

    public int Update(RoleDtoUpdate roleDtoUpdate)
    {
        var role = _roleRepository.GetByGuid(roleDtoUpdate.Guid);
        if (role is null) return -1;
        var roleUpdated = _roleRepository.Update(roleDtoUpdate);
        return roleUpdated ? 1 : 0;
    }

    public int Delete(Guid guid)
    {
        var role = _roleRepository.GetByGuid(guid);
        if (role is null) return -1;
        var roleDeleted = _roleRepository.Delete(role);
        return roleDeleted ? 1 : 0;
    }
}

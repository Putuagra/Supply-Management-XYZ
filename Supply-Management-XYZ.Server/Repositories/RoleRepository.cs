using Supply_Management_XYZ.Server.Contracts;
using Supply_Management_XYZ.Server.Data;
using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.Repositories;

public class RoleRepository : GeneralRepository<Role>, IRoleRepository
{
    public RoleRepository(SupplyManagementDbContext context) : base(context)
    {
    }
}

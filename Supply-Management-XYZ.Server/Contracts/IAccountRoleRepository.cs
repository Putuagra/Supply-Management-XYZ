using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.Contracts;

public interface IAccountRoleRepository : IGeneralRepository<AccountRole>
{
    IEnumerable<AccountRole> GetAccountRolesByAccountGuid(Guid guid);
}

using Supply_Management_XYZ.Server.Contracts;
using Supply_Management_XYZ.Server.Data;
using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.Repositories;

public class AccountRoleRepository : GeneralRepository<AccountRole>, IAccountRoleRepository
{
    public AccountRoleRepository(SupplyManagementDbContext context) : base(context)
    {
    }
    public IEnumerable<AccountRole> GetAccountRolesByAccountGuid(Guid guid)
    {
        return Context.Set<AccountRole>().Where(accountRole => accountRole.AccountGuid == guid);
    }
}

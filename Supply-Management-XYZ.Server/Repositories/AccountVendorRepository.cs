using Supply_Management_XYZ.Server.Contracts;
using Supply_Management_XYZ.Server.Data;
using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.Repositories
{
    public class AccountVendorRepository : GeneralRepository<AccountVendor>, IAccountVendorRepository
    {
        public AccountVendorRepository(SupplyManagementDbContext context) : base(context)
        {
        }
    }
}

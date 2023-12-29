using Supply_Management_XYZ.Server.Contracts;
using Supply_Management_XYZ.Server.Data;
using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.Repositories;

public class VendorRepository : GeneralRepository<Vendor>, IVendorRepository
{
    public VendorRepository(SupplyManagementDbContext context) : base(context)
    {
    }
}

using Supply_Management_XYZ.Server.Contracts;
using Supply_Management_XYZ.Server.Data;
using Supply_Management_XYZ.Server.DataTransferObjects.AccountVendors;
using Supply_Management_XYZ.Server.Models;
using Supply_Management_XYZ.Server.Utilities.Handlers;
using System.Security.Claims;

namespace Supply_Management_XYZ.Server.Services;

public class AccountVendorService
{
    private readonly SupplyManagementDbContext _supplyManagementDbContext;
    private readonly IAccountVendorRepository _accountVendorRepository;
    private readonly IVendorRepository _vendorRepository;
    private readonly ITokenHandler _tokenHandler;

    public AccountVendorService(IAccountVendorRepository accountVendorRepository, SupplyManagementDbContext supplyManagementDbContext, IVendorRepository vendorRepository, ITokenHandler tokenHandler)
    {
        _accountVendorRepository = accountVendorRepository;
        _supplyManagementDbContext = supplyManagementDbContext;
        _vendorRepository = vendorRepository;
        _tokenHandler = tokenHandler;
    }

    public IEnumerable<AccountVendorDtoGet> Get()
    {
        var accountVendors = _accountVendorRepository.GetAll().ToList();
        if (!accountVendors.Any()) return Enumerable.Empty<AccountVendorDtoGet>();
        List<AccountVendorDtoGet> accountVendorDtoGets = new List<AccountVendorDtoGet>();
        foreach (var accountVendor in accountVendors)
        {
            accountVendorDtoGets.Add((AccountVendorDtoGet)accountVendor);
        }
        return accountVendorDtoGets;
    }

    public AccountVendorDtoGet? Get(Guid guid)
    {
        var accountVendor = _accountVendorRepository.GetByGuid(guid);
        if (accountVendor is null) return null;
        return (AccountVendorDtoGet)accountVendor;
    }

    public AccountVendorDtoCreate? Create(AccountVendorDtoCreate accountVendorsDtoCreate)
    {
        var accountVendorCreated = _accountVendorRepository.Create(accountVendorsDtoCreate);
        if (accountVendorCreated is null) return null;
        return (AccountVendorDtoCreate)accountVendorCreated;
    }

    public int Update(AccountVendorDtoUpdate accountVendorDtoUpdate)
    {
        var accountVendor = _accountVendorRepository.GetByGuid(accountVendorDtoUpdate.Guid);
        if (accountVendor is null) return -1;
        var accountVendorUpdated = _accountVendorRepository.Update(accountVendorDtoUpdate);
        return accountVendorUpdated ? 1 : 0;
    }

    public int Delete(Guid guid)
    {
        var accountVendor = _accountVendorRepository.GetByGuid(guid);
        if (accountVendor is null) return -1;
        var accountVendorDeleted = _accountVendorRepository.Delete(accountVendor);
        return accountVendorDeleted ? 1 : 0;
    }

    public bool RegisterVendor(AccountVendorDtoRegister accountVendorDtoRegister)
    {
        using var transaction = _supplyManagementDbContext.Database.BeginTransaction();

        try
        {
            var vendor = new Vendor
            {
                Guid = new Guid(),
                Name = accountVendorDtoRegister.Name,
                Email = accountVendorDtoRegister.Email,
                PhoneNumber = accountVendorDtoRegister.PhoneNumber,
                PhotoProfile = accountVendorDtoRegister.PhotoProfile,
                Sector = "a",
                Type = "a",
                IsAdminApprove = false,
                IsManagerApprove = false,
            };
            _vendorRepository.Create(vendor);

            var accountVendor = new AccountVendor
            {
                Guid = vendor.Guid,
                Password = HashingHandler.Hash(accountVendorDtoRegister.Password),
            };
            _accountVendorRepository.Create(accountVendor);

            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }

    public string Login(AccountVendorDtoLogin accountVendorDtoLogin)
    {
        var vendor = _vendorRepository.GetVendorByEmail(accountVendorDtoLogin.Email);
        if (vendor is null) return "0";

        var accountVendor = _accountVendorRepository.GetByGuid(vendor.Guid);
        if (accountVendor is null) return "0";

        if (!HashingHandler.Validate(accountVendorDtoLogin.Password, accountVendor!.Password)) return "-1";

        try
        {
            var claims = new List<Claim>()
            {
                new Claim("Guid", vendor.Guid.ToString()),
                new Claim("Name", $"{vendor.Name}"),
                new Claim("PhotoProfile", vendor.PhotoProfile),
            };
            var token = _tokenHandler.GenerateToken(claims);
            return token;
        }
        catch
        {
            return "-2";
        }
    }
}

using Supply_Management_XYZ.Server.Contracts;
using Supply_Management_XYZ.Server.Data;
using Supply_Management_XYZ.Server.DataTransferObjects.Accounts;
using Supply_Management_XYZ.Server.Models;
using Supply_Management_XYZ.Server.Utilities.Handlers;

namespace Supply_Management_XYZ.Server.Services;

public class AccountService
{
    private readonly SupplyManagementDbContext _supplyManagementDbContext;
    private readonly IAccountRepository _accountRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public AccountService(SupplyManagementDbContext supplyManagementDbContext, IAccountRepository accountRepository, IEmployeeRepository employeeRepository)
    {
        _supplyManagementDbContext = supplyManagementDbContext;
        _accountRepository = accountRepository;
        _employeeRepository = employeeRepository;
    }

    public IEnumerable<AccountDtoGet> Get()
    {
        var accounts = _accountRepository.GetAll().ToList();
        if (!accounts.Any()) return Enumerable.Empty<AccountDtoGet>();
        List<AccountDtoGet> accountDtoGets = new List<AccountDtoGet>();
        foreach (var account in accounts)
        {
            accountDtoGets.Add((AccountDtoGet)account);
        }
        return accountDtoGets;
    }

    public AccountDtoGet? Get(Guid guid)
    {
        var account = _accountRepository.GetByGuid(guid);
        if (account is null) return null;
        return (AccountDtoGet)account;
    }

    public AccountDtoCreate? Create(AccountDtoCreate accountDtoCreate)
    {
        var accountCreated = _accountRepository.Create(accountDtoCreate);
        if (accountCreated is null) return null;
        return (AccountDtoCreate)accountCreated;
    }

    public int Update(AccountDtoUpdate accountDtoUpdate)
    {
        var account = _accountRepository.GetByGuid(accountDtoUpdate.Guid);
        if (account is null) return -1;
        var accountUpdated = _accountRepository.Update(accountDtoUpdate);
        return accountUpdated ? 1 : 0;
    }

    public int Delete(Guid guid)
    {
        var account = _accountRepository.GetByGuid(guid);
        if (account is null) return -1;
        var accountDeleted = _accountRepository.Delete(account);
        return accountDeleted ? 1 : 0;
    }

    public bool RegisterEmployee(AccountEmployeeDtoRegister accountEmployeeDtoRegister)
    {
        using var transaction = _supplyManagementDbContext.Database.BeginTransaction();

        try
        {
            var employee = new Employee
            {
                Guid = new Guid(),
                FirstName = accountEmployeeDtoRegister.FirstName,
                LastName = accountEmployeeDtoRegister.LastName,
                Email = accountEmployeeDtoRegister.Email,
            };
            _employeeRepository.Create(employee);

            var account = new Account
            {
                Guid = employee.Guid,
                Password = HashingHandler.Hash(accountEmployeeDtoRegister.Password),
            };
            _accountRepository.Create(account);

            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
}

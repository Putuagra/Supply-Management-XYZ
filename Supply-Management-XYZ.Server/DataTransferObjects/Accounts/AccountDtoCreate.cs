using Supply_Management_XYZ.Server.Models;
using Supply_Management_XYZ.Server.Utilities.Handlers;

namespace Supply_Management_XYZ.Server.DataTransferObjects.Accounts;

public class AccountDtoCreate
{
    public Guid Guid { get; set; }
    public string Password { get; set; }

    public static implicit operator Account(AccountDtoCreate accountDtoCreate)
    {
        return new Account
        {
            Guid = accountDtoCreate.Guid,
            Password = HashingHandler.Hash(accountDtoCreate.Password),
            CreatedDate = DateTime.UtcNow
        };
    }

    public static explicit operator AccountDtoCreate(Account account)
    {
        return new AccountDtoCreate
        {
            Guid = account.Guid,
            Password = account.Password,
        };
    }
}

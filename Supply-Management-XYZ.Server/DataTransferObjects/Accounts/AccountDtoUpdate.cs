using Supply_Management_XYZ.Server.Models;
using Supply_Management_XYZ.Server.Utilities.Handlers;

namespace Supply_Management_XYZ.Server.DataTransferObjects.Accounts;

public class AccountDtoUpdate
{
    public Guid Guid { get; set; }
    public string Password { get; set; }

    // implicit operator
    public static implicit operator Account(AccountDtoUpdate accountDtoUpdate)
    {
        return new()
        {
            Guid = accountDtoUpdate.Guid,
            Password = HashingHandler.Hash(accountDtoUpdate.Password),
            ModifiedDate = DateTime.UtcNow
        };
    }

    public static explicit operator AccountDtoUpdate(Account account)
    {
        return new()
        {
            Guid = account.Guid,
            Password = account.Password,
        };
    }
}

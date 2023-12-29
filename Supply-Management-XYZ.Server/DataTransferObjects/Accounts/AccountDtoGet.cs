using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.DataTransferObjects.Accounts;

public class AccountDtoGet
{
    public Guid Guid { get; set; }
    public string Password { get; set; }

    public static implicit operator Account(AccountDtoGet accountDtoGet)
    {
        return new()
        {
            Guid = accountDtoGet.Guid,
            Password = accountDtoGet.Password,
        };
    }

    public static explicit operator AccountDtoGet(Account account)
    {
        return new()
        {
            Guid = account.Guid,
            Password = account.Password,
        };
    }
}

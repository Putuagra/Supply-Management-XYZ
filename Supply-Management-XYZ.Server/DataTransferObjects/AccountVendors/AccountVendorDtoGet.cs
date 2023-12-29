using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.DataTransferObjects.AccountVendors;

public class AccountVendorDtoGet
{
    public Guid Guid { get; set; }
    public string Password { get; set; }

    public static implicit operator AccountVendor(AccountVendorDtoGet accountVendorsDtoGet)
    {
        return new()
        {
            Guid = accountVendorsDtoGet.Guid,
            Password = accountVendorsDtoGet.Password,
        };
    }

    public static explicit operator AccountVendorDtoGet(AccountVendor accountVendor)
    {
        return new()
        {
            Guid = accountVendor.Guid,
            Password = accountVendor.Password,
        };
    }
}

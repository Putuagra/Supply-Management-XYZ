using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.DataTransferObjects.AccountVendors;

public class AccountVendorDtoUpdate
{
    public Guid Guid { get; set; }
    public string Password { get; set; }

    public static implicit operator AccountVendor(AccountVendorDtoUpdate accountVendorsDtoUpdate)
    {
        return new()
        {
            Guid = accountVendorsDtoUpdate.Guid,
            Password = accountVendorsDtoUpdate.Password,
        };
    }

    public static explicit operator AccountVendorDtoUpdate(AccountVendor accountVendor)
    {
        return new()
        {
            Guid = accountVendor.Guid,
            Password = accountVendor.Password,
        };
    }
}

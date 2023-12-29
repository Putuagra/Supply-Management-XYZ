using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.DataTransferObjects.AccountVendors;

public class AccountVendorDtoCreate
{
    public Guid Guid { get; set; }
    public string Password { get; set; }

    public static implicit operator AccountVendor(AccountVendorDtoCreate accountVendorsDtoCreate)
    {
        return new()
        {
            Guid = accountVendorsDtoCreate.Guid,
            Password = accountVendorsDtoCreate.Password,
        };
    }

    public static explicit operator AccountVendorDtoCreate(AccountVendor accountVendor)
    {
        return new()
        {
            Guid = accountVendor.Guid,
            Password = accountVendor.Password,
        };
    }
}

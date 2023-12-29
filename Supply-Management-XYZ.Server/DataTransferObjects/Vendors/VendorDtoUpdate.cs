using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.DataTransferObjects.Vendors;

public class VendorDtoUpdate
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PhotoProfile { get; set; }
    public string Sector { get; set; }
    public string Type { get; set; }
    public bool IsApprove { get; set; }

    public static implicit operator Vendor(VendorDtoUpdate vendorDtoUpdate)
    {
        return new()
        {
            Guid = vendorDtoUpdate.Guid,
            Name = vendorDtoUpdate.Name,
            Email = vendorDtoUpdate.Email,
            PhoneNumber = vendorDtoUpdate.PhoneNumber,
            PhotoProfile = vendorDtoUpdate.PhotoProfile,
            Sector = vendorDtoUpdate.Sector,
            Type = vendorDtoUpdate.Type,
            IsApprove = vendorDtoUpdate.IsApprove,
        };
    }

    public static explicit operator VendorDtoUpdate(Vendor vendor)
    {
        return new()
        {
            Guid = vendor.Guid,
            Name = vendor.Name,
            Email = vendor.Email,
            PhoneNumber = vendor.PhoneNumber,
            PhotoProfile = vendor.PhotoProfile,
            Sector = vendor.Sector,
            Type = vendor.Type,
            IsApprove = vendor.IsApprove,
        };
    }
}

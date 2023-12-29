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
    public bool IsAdminApprove { get; set; }
    public bool IsManagerApprove { get; set; }

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
            IsAdminApprove = vendorDtoUpdate.IsAdminApprove,
            IsManagerApprove = vendorDtoUpdate.IsManagerApprove,
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
            IsAdminApprove = vendor.IsAdminApprove,
            IsManagerApprove = vendor.IsManagerApprove,
        };
    }
}

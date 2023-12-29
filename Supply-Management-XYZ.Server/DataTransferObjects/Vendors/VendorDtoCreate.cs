using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.DataTransferObjects.Vendors;

public class VendorDtoCreate
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PhotoProfile { get; set; }
    public string Sector { get; set; }
    public string Type { get; set; }
    public bool IsAdminApprove { get; set; }
    public bool IsManagerApprove { get; set; }

    public static implicit operator Vendor(VendorDtoCreate vendorDtoCreate)
    {
        return new()
        {
            Name = vendorDtoCreate.Name,
            Email = vendorDtoCreate.Email,
            PhoneNumber = vendorDtoCreate.PhoneNumber,
            PhotoProfile = vendorDtoCreate.PhotoProfile,
            Sector = vendorDtoCreate.Sector,
            Type = vendorDtoCreate.Type,
            IsAdminApprove = vendorDtoCreate.IsAdminApprove,
            IsManagerApprove = vendorDtoCreate.IsManagerApprove,
        };
    }

    public static explicit operator VendorDtoCreate(Vendor vendor)
    {
        return new()
        {
            Name = vendor.Name,
            Email = vendor.Email,
            PhoneNumber = vendor.PhoneNumber,
            PhotoProfile = vendor.PhotoProfile,
            Sector = vendor.Sector,
            Type = vendor.Type,
            IsAdminApprove = vendor.IsAdminApprove,
            IsManagerApprove = vendor.IsManagerApprove
        };
    }
}

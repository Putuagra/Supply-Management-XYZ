﻿using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.Contracts;

public interface IVendorRepository : IGeneralRepository<Vendor>
{
    Vendor? GetVendorByEmail(string email);
}

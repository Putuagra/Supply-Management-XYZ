﻿using Supply_Management_XYZ.Server.Contracts;
using Supply_Management_XYZ.Server.Data;
using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.Repositories;

public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(SupplyManagementDbContext context) : base(context)
    {
    }

    public Employee? GetEmployeeByEmail(string email)
    {
        return Context.Set<Employee>().FirstOrDefault(e => e.Email == email);
    }
}

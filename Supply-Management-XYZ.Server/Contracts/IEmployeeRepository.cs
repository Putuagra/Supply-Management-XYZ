using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.Contracts;

public interface IEmployeeRepository : IGeneralRepository<Employee>
{
    Employee? GetEmployeeByEmail(string email);
}

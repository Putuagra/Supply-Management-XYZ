using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.DataTransferObjects.Employees;

public class EmployeeDtoGet
{
    public Guid Guid { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }

    public static implicit operator Employee(EmployeeDtoGet employeeDtoGet)
    {
        return new()
        {
            Guid = employeeDtoGet.Guid,
            FirstName = employeeDtoGet.FirstName,
            LastName = employeeDtoGet.LastName,
            Email = employeeDtoGet.Email,
        };
    }

    public static explicit operator EmployeeDtoGet(Employee employee)
    {
        return new()
        {
            Guid = employee.Guid,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
        };
    }
}

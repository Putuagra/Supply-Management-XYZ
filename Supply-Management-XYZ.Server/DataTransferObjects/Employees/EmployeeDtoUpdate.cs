using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.DataTransferObjects.Employees;

public class EmployeeDtoUpdate
{
    public Guid Guid { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }

    public static implicit operator Employee(EmployeeDtoUpdate employeeDtoUpdate)
    {
        return new()
        {
            Guid = employeeDtoUpdate.Guid,
            FirstName = employeeDtoUpdate.FirstName,
            LastName = employeeDtoUpdate.LastName,
            Email = employeeDtoUpdate.Email,
        };
    }

    public static explicit operator EmployeeDtoUpdate(Employee employee)
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

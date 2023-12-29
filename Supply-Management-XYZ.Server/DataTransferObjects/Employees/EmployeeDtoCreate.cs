using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.DataTransferObjects.Employees;

public class EmployeeDtoCreate
{
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }

    public static implicit operator Employee(EmployeeDtoCreate employeeDtoCreate)
    {
        return new()
        {
            FirstName = employeeDtoCreate.FirstName,
            LastName = employeeDtoCreate.LastName,
            Email = employeeDtoCreate.Email,
        };
    }

    public static explicit operator EmployeeDtoCreate(Employee employee)
    {
        return new()
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
        };
    }
}

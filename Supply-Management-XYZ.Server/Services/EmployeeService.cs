using Supply_Management_XYZ.Server.Contracts;
using Supply_Management_XYZ.Server.DataTransferObjects.Employees;

namespace Supply_Management_XYZ.Server.Services;

public class EmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public IEnumerable<EmployeeDtoGet> Get()
    {
        var employees = _employeeRepository.GetAll().ToList();
        if (!employees.Any()) return Enumerable.Empty<EmployeeDtoGet>();
        List<EmployeeDtoGet> employeeDtoGets = new List<EmployeeDtoGet>();
        foreach (var account in employees)
        {
            employeeDtoGets.Add((EmployeeDtoGet)account);
        }
        return employeeDtoGets;
    }

    public EmployeeDtoGet? Get(Guid guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);
        if (employee is null) return null;
        return (EmployeeDtoGet)employee;
    }

    public EmployeeDtoCreate? Create(EmployeeDtoCreate employeeDtoCreate)
    {
        var employeeCreated = _employeeRepository.Create(employeeDtoCreate);
        if (employeeCreated is null) return null;
        return (EmployeeDtoCreate)employeeCreated;
    }

    public int Update(EmployeeDtoUpdate employeeDtoUpdate)
    {
        var employee = _employeeRepository.GetByGuid(employeeDtoUpdate.Guid);
        if (employee is null) return -1;
        var accountUpdated = _employeeRepository.Update(employeeDtoUpdate);
        return accountUpdated ? 1 : 0;
    }

    public int Delete(Guid guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);
        if (employee is null) return -1;
        var employeeDeleted = _employeeRepository.Delete(employee);
        return employeeDeleted ? 1 : 0;
    }
}

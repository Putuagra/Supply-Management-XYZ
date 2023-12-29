using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.DataTransferObjects.Projects;

public class ProjectDtoCreate
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid VendorGuid { get; set; }

    public static implicit operator Project(ProjectDtoCreate projectDtoCreate)
    {
        return new()
        {
            Name = projectDtoCreate.Name,
            Description = projectDtoCreate.Description,
            VendorGuid = projectDtoCreate.VendorGuid,
        };
    }

    public static explicit operator ProjectDtoCreate(Project project)
    {
        return new()
        {
            Name = project.Name,
            Description = project.Description,
            VendorGuid = project.VendorGuid,
        };
    }
}

using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.DataTransferObjects.Projects;

public class ProjectDtoUpdate
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid VendorGuid { get; set; }

    public static implicit operator Project(ProjectDtoUpdate projectDtoUpdate)
    {
        return new()
        {
            Guid = projectDtoUpdate.Guid,
            Name = projectDtoUpdate.Name,
            Description = projectDtoUpdate.Description,
            VendorGuid = projectDtoUpdate.VendorGuid,
        };
    }

    public static explicit operator ProjectDtoUpdate(Project project)
    {
        return new()
        {
            Guid = project.Guid,
            Name = project.Name,
            Description = project.Description,
            VendorGuid = project.VendorGuid,
        };
    }
}

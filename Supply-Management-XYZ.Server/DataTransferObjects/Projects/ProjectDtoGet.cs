using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.DataTransferObjects.Projects;

public class ProjectDtoGet
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid VendorGuid { get; set; }

    public static implicit operator Project(ProjectDtoGet projectDtoGet)
    {
        return new()
        {
            Guid = projectDtoGet.Guid,
            Name = projectDtoGet.Name,
            Description = projectDtoGet.Description,
            VendorGuid = projectDtoGet.VendorGuid,
        };
    }

    public static explicit operator ProjectDtoGet(Project project)
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

﻿using Supply_Management_XYZ.Server.Contracts;
using Supply_Management_XYZ.Server.DataTransferObjects.Projects;

namespace Supply_Management_XYZ.Server.Services;

public class ProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public IEnumerable<ProjectDtoGet> Get()
    {
        var projects = _projectRepository.GetAll().ToList();
        if (!projects.Any()) return Enumerable.Empty<ProjectDtoGet>();
        List<ProjectDtoGet> projectDtoGets = new List<ProjectDtoGet>();
        foreach (var project in projects)
        {
            projectDtoGets.Add((ProjectDtoGet)project);
        }
        return projectDtoGets;
    }

    public ProjectDtoGet? Get(Guid guid)
    {
        var project = _projectRepository.GetByGuid(guid);
        if (project is null) return null;
        return (ProjectDtoGet)project;
    }

    public ProjectDtoCreate? Create(ProjectDtoCreate projectDtoCreate)
    {
        var projectCreated = _projectRepository.Create(projectDtoCreate);
        if (projectCreated is null) return null;
        return (ProjectDtoCreate)projectCreated;
    }

    public int Update(ProjectDtoUpdate projectDtoUpdate)
    {
        var project = _projectRepository.GetByGuid(projectDtoUpdate.Guid);
        if (project is null) return -1;
        var projectUpdated = _projectRepository.Update(projectDtoUpdate);
        return projectUpdated ? 1 : 0;
    }

    public int Delete(Guid guid)
    {
        var project = _projectRepository.GetByGuid(guid);
        if (project is null) return -1;
        var projectDeleted = _projectRepository.Delete(project);
        return projectDeleted ? 1 : 0;
    }
}

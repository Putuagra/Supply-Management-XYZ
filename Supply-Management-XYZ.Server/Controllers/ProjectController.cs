using Microsoft.AspNetCore.Mvc;
using Supply_Management_XYZ.Server.DataTransferObjects.Projects;
using Supply_Management_XYZ.Server.Services;
using Supply_Management_XYZ.Server.Utilities.Handlers;
using System.Net;

namespace Supply_Management_XYZ.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly ProjectService _projectService;

    public ProjectController(ProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var projects = _projectService.Get();
        if (!projects.Any())
        {
            return NotFound(new ResponseHandler<ProjectDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Project not found"
            });
        }
        return Ok(new ResponseHandler<IEnumerable<ProjectDtoGet>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Projects found",
            Data = projects
        });
    }

    [HttpGet("{guid}")]
    public IActionResult Get(Guid guid)
    {
        var project = _projectService.Get(guid);
        if (project is null)
        {
            return NotFound(new ResponseHandler<ProjectDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Project not found"
            });
        }

        return Ok(new ResponseHandler<ProjectDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Project found",
            Data = project
        });
    }

    [HttpPost]
    public IActionResult Create(ProjectDtoCreate projectDtoCreate)
    {
        var projectCreated = _projectService.Create(projectDtoCreate);
        if (projectCreated is null)
        {
            return BadRequest(new ResponseHandler<ProjectDtoCreate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Project not created"
            });
        }

        return Ok(new ResponseHandler<ProjectDtoCreate>
        {
            Code = StatusCodes.Status201Created,
            Status = HttpStatusCode.Created.ToString(),
            Message = "Project successfully created",
            Data = projectCreated
        });
    }

    [HttpPut]
    public IActionResult Update(ProjectDtoUpdate projectDtoUpdate)
    {
        var projectUpdated = _projectService.Update(projectDtoUpdate);
        if (projectUpdated is -1)
        {
            return NotFound(new ResponseHandler<ProjectDtoUpdate>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Project not found"
            });
        }

        if (projectUpdated is 0)
        {
            return BadRequest(new ResponseHandler<ProjectDtoUpdate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Project not updated"
            });
        }

        return Ok(new ResponseHandler<ProjectDtoUpdate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Project successfully updated",
            Data = projectDtoUpdate
        });
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        var projectDeleted = _projectService.Delete(guid);
        if (projectDeleted is -1)
        {
            return NotFound(new ResponseHandler<ProjectDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Project not found"
            });
        }

        if (projectDeleted is 0)
        {
            return BadRequest(new ResponseHandler<ProjectDtoGet>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Project not deleted"
            });
        }

        return Ok(new ResponseHandler<ProjectDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Project successfully deleted"
        });
    }
}

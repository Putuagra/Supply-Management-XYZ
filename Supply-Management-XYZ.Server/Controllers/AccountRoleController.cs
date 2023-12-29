using Microsoft.AspNetCore.Mvc;
using Supply_Management_XYZ.Server.DataTransferObjects.AccountRoles;
using Supply_Management_XYZ.Server.Services;
using Supply_Management_XYZ.Server.Utilities.Handlers;
using System.Net;

namespace Supply_Management_XYZ.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountRoleController : ControllerBase
{
    private readonly AccountRoleService _accountRoleService;

    public AccountRoleController(AccountRoleService accountRoleService)
    {
        _accountRoleService = accountRoleService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var accountRoles = _accountRoleService.Get();

        if (!accountRoles.Any())
        {
            return NotFound(new ResponseHandler<AccountRoleDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Account role not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<AccountRoleDtoGet>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Account roles found",
            Data = accountRoles
        });
    }

    [HttpGet("{guid}")]
    public IActionResult Get(Guid guid)
    {
        var accountRole = _accountRoleService.Get(guid);
        if (accountRole is null)
        {
            return NotFound(new ResponseHandler<AccountRoleDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Account role not found"
            });
        }

        return Ok(new ResponseHandler<AccountRoleDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Account role found",
            Data = accountRole
        });
    }

    [HttpPost]
    public IActionResult Create(AccountRoleDtoCreate accountRoleDtoCreate)
    {
        var accountRoleCreated = _accountRoleService.Create(accountRoleDtoCreate);
        if (accountRoleCreated is null)
        {
            return BadRequest(new ResponseHandler<AccountRoleDtoCreate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Account role not created"
            });
        }

        return Ok(new ResponseHandler<AccountRoleDtoCreate>
        {
            Code = StatusCodes.Status201Created,
            Status = HttpStatusCode.Created.ToString(),
            Message = "Account role successfully created",
            Data = accountRoleCreated
        });
    }

    [HttpPut]
    public IActionResult Update(AccountRoleDtoUpdate accountRoleDtoUpdate)
    {
        var accountRoleUpdated = _accountRoleService.Update(accountRoleDtoUpdate);

        if (accountRoleUpdated is -1)
        {
            return NotFound(new ResponseHandler<AccountRoleDtoUpdate>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Account role not found"
            });
        }

        if (accountRoleUpdated is 0)
        {
            return BadRequest(new ResponseHandler<AccountRoleDtoUpdate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Account role not updated"
            });
        }

        return Ok(new ResponseHandler<AccountRoleDtoUpdate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Account role successfully updated",
            Data = accountRoleDtoUpdate
        });
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        var accountRoleDeleted = _accountRoleService.Delete(guid);

        if (accountRoleDeleted is -1)
        {
            return NotFound(new ResponseHandler<AccountRoleDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Account role not found"
            });
        }

        if (accountRoleDeleted is 0)
        {
            return BadRequest(new ResponseHandler<AccountRoleDtoGet>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Account role not deleted"
            });
        }

        return Ok(new ResponseHandler<AccountRoleDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Account role successfully deleted"
        });
    }
}

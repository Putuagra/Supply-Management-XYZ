using Microsoft.AspNetCore.Mvc;
using Supply_Management_XYZ.Server.DataTransferObjects.AccountVendors;
using Supply_Management_XYZ.Server.Services;
using Supply_Management_XYZ.Server.Utilities.Handlers;
using System.Net;

namespace Supply_Management_XYZ.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountVendorController : ControllerBase
{
    private readonly AccountVendorService _accountVendorService;

    public AccountVendorController(AccountVendorService accountVendorService)
    {
        _accountVendorService = accountVendorService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var accountVendors = _accountVendorService.Get();
        if (!accountVendors.Any())
        {
            return NotFound(new ResponseHandler<AccountVendorDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Account Vendor not found"
            });
        }
        return Ok(new ResponseHandler<IEnumerable<AccountVendorDtoGet>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Account Vendors found",
            Data = accountVendors
        });
    }

    [HttpGet("{guid}")]
    public IActionResult Get(Guid guid)
    {
        var accountVendor = _accountVendorService.Get(guid);
        if (accountVendor is null)
        {
            return NotFound(new ResponseHandler<AccountVendorDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Account Vendor not found"
            });
        }

        return Ok(new ResponseHandler<AccountVendorDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Account Vendor found",
            Data = accountVendor
        });
    }

    [HttpPost]
    public IActionResult Create(AccountVendorDtoCreate accountVendorDtoCreate)
    {
        var accountVendorCreated = _accountVendorService.Create(accountVendorDtoCreate);
        if (accountVendorCreated is null)
        {
            return BadRequest(new ResponseHandler<AccountVendorDtoCreate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Account Vendor not created"
            });
        }

        return Ok(new ResponseHandler<AccountVendorDtoCreate>
        {
            Code = StatusCodes.Status201Created,
            Status = HttpStatusCode.Created.ToString(),
            Message = "Account Vendor successfully created",
            Data = accountVendorCreated
        });
    }

    [HttpPut]
    public IActionResult Update(AccountVendorDtoUpdate accountVendorDtoUpdate)
    {
        var accountVendorUpdated = _accountVendorService.Update(accountVendorDtoUpdate);
        if (accountVendorUpdated is -1)
        {
            return NotFound(new ResponseHandler<AccountVendorDtoUpdate>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Account Vendor not found"
            });
        }

        if (accountVendorUpdated is 0)
        {
            return BadRequest(new ResponseHandler<AccountVendorDtoUpdate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Account Vendor not updated"
            });
        }

        return Ok(new ResponseHandler<AccountVendorDtoUpdate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Account Vendor successfully updated",
            Data = accountVendorDtoUpdate
        });
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        var accountVendorDeleted = _accountVendorService.Delete(guid);
        if (accountVendorDeleted is -1)
        {
            return NotFound(new ResponseHandler<AccountVendorDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Account Vendor not found"
            });
        }

        if (accountVendorDeleted is 0)
        {
            return BadRequest(new ResponseHandler<AccountVendorDtoGet>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Account Vendor not deleted"
            });
        }

        return Ok(new ResponseHandler<AccountVendorDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Account Vendor successfully deleted"
        });
    }

    [HttpPost("registerVendor")]
    public IActionResult RegiterVendor(AccountVendorDtoRegister accountVendorDtoRegister)
    {
        var isCreated = _accountVendorService.RegisterVendor(accountVendorDtoRegister);
        if (!isCreated)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<AccountVendorDtoRegister>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Vendor not registered",
                Data = null
            });
        return Ok(new ResponseHandler<AccountVendorDtoRegister>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Vendor registered",
            Data = accountVendorDtoRegister
        });
    }
}

using ListR.Common.Interfaces.Services;
using ListR.DataLayer.EntityModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ListR.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserGroupController : Controller
{
    private readonly IUserGroupService _userGroupService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserGroupController(IUserGroupService userGroupService,
        IHttpContextAccessor httpContextAccessor)
    {
        _userGroupService = userGroupService;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet()]
    public async Task<IActionResult> GetByEmail()
    {
        var loggedInUser = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value;
        return Ok(await _userGroupService.GetUserGroupsByEmail(loggedInUser));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserGroup([FromBody] UserGroup model)
    {
        await _userGroupService.CreateUserGroup(model);
        return Ok();
    }

    [HttpPut("add-user/{email}/{groupId}")]
    public async Task<IActionResult> AddUserToGroup([FromRoute] string email, [FromRoute] int groupId)
    {
        await _userGroupService.AddUsersToUserGroup(new List<string> { email }, groupId);
        return Ok();
    }
}
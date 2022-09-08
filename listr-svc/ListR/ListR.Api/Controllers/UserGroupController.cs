using ListR.Common.Interfaces.Services;
using ListR.DataLayer.EntityModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ListR.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class UserGroupController : Controller
{
    private readonly IUserGroupService _userGroupService;

    public UserGroupController(IUserGroupService userGroupService)
    {
        _userGroupService = userGroupService;
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> GetByEmail([FromRoute] string email = "tristanvdm87@gmail.com")
    {
        return Ok(await _userGroupService.GetUserGroupsByEmail(email));
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
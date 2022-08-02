using ListR.Common.Interfaces.Services;
using ListR.DataLayer.EntityModels.Users;
using ListR.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace ListR.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("{email}")]
    public async Task<IActionResult> GetUser([FromRoute] string email)
    {
        return Ok(await _userService.GetUser(email));
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateUser([FromBody] User model)
    {
        await _userService.UpdateUser(model);
        return Ok();
    }
}
using ListR.DataLayer.EntityModels.Users;
using ListR.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace ListR.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("{email}")]
    public async Task<IActionResult> GetUser([FromQuery] string email)
    {
        return Ok(await _userService.GetUser(email));
    }
}
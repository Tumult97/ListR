using ListR.Common.Interfaces.Services;
using ListR.Common.Models.ApiActions;
using ListR.Common.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ListR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {

        #region Services
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Setup
        public AuthenticationController(IAuthenticationService authenticationService, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _authenticationService = authenticationService;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Api Endpoints

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _authenticationService.Login(model);

            if (user == null)
                return NotFound("Incorrect login combination.");

            var token = GetToken(user.claims);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        [HttpPost]
        [Route("loginauth")]
        public async Task<IActionResult> LoginAuth()
        {
            var user = await _authenticationService.Login(new LoginModel
            {
                Password = "Tiberium-97",
                Username = "tristanvdm87@gmail.com"
            });

            if (user == null)
                return NotFound("Incorrect login combination.");

            var token = GetToken(user.claims);

            return Ok("Bearer " + (new JwtSecurityTokenHandler().WriteToken(token).ToString()));
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var result = await _authenticationService.Register(model);

            if (!result.Success)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = result.Error });

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var result = await _authenticationService.RegisterAdmin(model);

            if (!result.Success)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = result.Error });

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpGet]
        [Route("validate")]
        [Authorize]
        public ActionResult ValidateAuthorisation()
        {
            var claims = _httpContextAccessor.HttpContext?.User.Claims.ToList();
            var token = GetToken(claims);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        #endregion

        #region Private Methods
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                authClaims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(1),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        #endregion
    }
}

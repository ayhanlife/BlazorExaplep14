using BlazorExaplep14.API.Helpers;
using BlazorExaplep14.Common;
using BlazorExaplep14.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlazorExaplep14.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ITokenService tokenService;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ITokenService tokenService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] UserRequestDto userRequestDto)
        {
            if (userRequestDto is null || !ModelState.IsValid)
                return BadRequest();

            var user = new IdentityUser
            {
                UserName = userRequestDto.Email,
                Email = userRequestDto.Email,
                PhoneNumber = userRequestDto.PhoneNo,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, userRequestDto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new Result<IEnumerable<string>>(false, ResultConstant.IdNotNull, errors));
            }

            var roleResult = await userManager.AddToRoleAsync(user, ResultConstant.Role_Customer);
            if (!roleResult.Succeeded)
            {
                var errors = roleResult.Errors.Select(e => e.Description);
                return BadRequest(new Result<IEnumerable<string>>(false, ResultConstant.IdNotNull, errors));
            }

            return StatusCode(201);
        }

         

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] SingInDto signDto)
        {
            var result = await signInManager.PasswordSignInAsync(signDto.UserName, signDto.Password, false, false);

            if (result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(signDto.UserName);
                if (user == null)
                {
                    return Unauthorized(new Result<IActionResult>(false, ResultConstant.InvalidAuthentication));
                }

                var returnData = new UserDto
                {
                    UserName = user.UserName,
                    Id = user.Id,
                    Email = user.Email,
                    PhoneNo = user.PhoneNumber,
                    Token = tokenService.CreateToken(user)
                };
                return Ok(new Result<UserDto>(true, ResultConstant.TokenResponseMessage, returnData));
            }
            else
            {
                return Unauthorized(new Result<IActionResult>(false, ResultConstant.InvalidAuthentication));
            }
        }
    }
}

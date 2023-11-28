using System;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Login.Server.Models;
using Blazor.Login.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Login.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            var singInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!singInResult.Succeeded)
            {
                return BadRequest("Invalid password");
            }

            await _signInManager.SignInAsync(user, request.RememberMe);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest parameters)
        {
            var user = new User
            {
                UserName = parameters.UserName,
                Password = parameters.Password,
                FirstName = parameters.FirstName,
                LastName = parameters.LastName,
                CreatedAt = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, parameters.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.FirstOrDefault()?.Description);
            }

            return await Login(new LoginRequest
            {
                UserName = parameters.UserName,
                Password = parameters.Password
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet]
        public CurrentUser CurrentUserInfo()
        {
            return new CurrentUser
            {
                IsAuthenticated = User.Identity.IsAuthenticated,
                UserName = User.Identity.Name,
                Claims = User.Claims.ToDictionary(c => c.Type, c => c.Value)
            };
        }
    }
}
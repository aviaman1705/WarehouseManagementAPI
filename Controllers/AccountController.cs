using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcTaskManager.Identity;
using MvcTaskManager.Models.ViewModels;
using MvcTaskManager.ServiceContracts;

namespace MvcTaskManager.Controllers
{
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IAntiforgery _antiforgery;
        private readonly ApplicationSignInManager _applicationSignInManager;
        private readonly ILogger<ProductsController> _logger;
        public AccountController(
            IUsersService usersService,
            ApplicationSignInManager applicationSignManager,
            IAntiforgery antiforgery,
            ILogger<ProductsController> logger)
        {
            this._usersService = usersService;
            this._applicationSignInManager = applicationSignManager;
            this._antiforgery = antiforgery;
            _logger = logger;
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]LoginViewModel loginViewModel)
        {
            try
            {
                var user = await _usersService.Authenticate(loginViewModel);
                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                HttpContext.User = await _applicationSignInManager.CreateUserPrincipalAsync(user);
                var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
                Response.Headers.Add("Access-Control-Expose-Headers", "XSRF-REQUEST-TOKEN");
                Response.Headers.Add("XSRF-REQUEST-TOKEN", tokens.RequestToken);

                _logger.LogInformation($"{Environment.NewLine} Authenticate function");
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Environment.NewLine} {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]SignUpViewModel signUpViewModel)
        {
            try
            {
                var user = await _usersService.Register(signUpViewModel);
                if (user == null)
                    return BadRequest(new { message = "Invalid Data" });

                HttpContext.User = await _applicationSignInManager.CreateUserPrincipalAsync(user);
                var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
                Response.Headers.Add("Access-Control-Expose-Headers", "XSRF-REQUEST-TOKEN");
                Response.Headers.Add("XSRF-REQUEST-TOKEN", tokens.RequestToken);

                _logger.LogInformation($"{Environment.NewLine} Register function");
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Environment.NewLine} {ex.Message}");
                throw;
            }
        }

        [Route("api/getUserByEmail/{Email}")]
        public async Task<IActionResult> GetUserByEmail(string Email)
        {
            try
            {
                var user = await _usersService.GetUserByEmail(Email);
                _logger.LogInformation($"{Environment.NewLine} GetUserByEmail function {Email}");
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Environment.NewLine} {ex.Message}");
                throw;
            }
        }
    }
}



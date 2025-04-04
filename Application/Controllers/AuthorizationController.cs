using Common.Enum;
using Dto.AuthorizationDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.AuthorizationService;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {
        private readonly AuthorizationService _authorizationService;

        public AuthorizationController(AuthorizationService authorizationService) 
        {
            _authorizationService = authorizationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var loginResponse = await _authorizationService.LoginAsync(loginDto.UsernameOrEmail, loginDto.Password);

            if (loginResponse.StatusCode == MyStatusCode.Unauthorized)
            {
                switch (loginResponse.AuthStatus)
                {
                    case AuthStatus.UserNotFound:
                        return Unauthorized("User not found");

                    case AuthStatus.IncorrectPassword:
                        return Unauthorized("Incorrect password");

                    case AuthStatus.TokenRefreshFailed:
                        return Unauthorized("Token refresh failed");

                    default:
                        return Unauthorized("Unauthorized");
                }
            }

            return Ok(loginResponse);

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var registerResponse = await _authorizationService.RegisterAsync(registerDto);

            if (registerResponse.StatusCode == MyStatusCode.Unauthorized)
            {
                switch (registerResponse.AuthStatus)
                {
                    case AuthStatus.UsernameIsTaken:
                        return Unauthorized("Username already taken");

                    case AuthStatus.EmailIsAlredyRegister:
                        return Unauthorized("This email address already register.");

                    case AuthStatus.IncorrectPassword:
                        return Unauthorized("Simple password");

                    default:
                        return Unauthorized("Unauthorized");
                }
            }

            return Ok(registerResponse);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokensDto tokensDto)
        {
            var authResponse = await _authorizationService.RefreshTokenAsync(tokensDto.AccessToken, tokensDto.RefreshToken);

            if (authResponse.StatusCode == MyStatusCode.Unauthorized && 
                authResponse.AuthStatus == AuthStatus.TokenRefreshFailed)
            {
                return Unauthorized("Invalid refresh token");
            }

            return Ok(authResponse);
        }
    }
}

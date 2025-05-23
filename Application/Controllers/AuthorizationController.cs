﻿using Common.Enum;
using Domain.Entity.User;
using Dto.AuthorizationDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Implementations.HighLevelServices;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {
        private readonly AuthorizationService _authorizationService;
        private readonly SignInManager<User> _signInManager;

        public AuthorizationController(AuthorizationService authorizationService, SignInManager<User> signInManager) 
        {
            _authorizationService = authorizationService;
            _signInManager = signInManager;
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

                    case AuthStatus.NotConfirmedPassword:
                        return Unauthorized("Not confirmed password");

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

        [HttpGet("google-login")]
        public IActionResult GoogleLogin()
        {
            var redirectUrl = Url.Action("GoogleCallback", "Authorization", null, Request.Scheme);
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return Challenge(properties, "Google");
        }


        [HttpGet("google-callback")]
        public async Task<IActionResult> GoogleCallback()
        {
            var result = await _authorizationService.ExternalLoginAsync();

            // Логирование результата
            Console.WriteLine("Google Callback Result: " + result);

            if (result.Data == null)
            {
                return BadRequest("Google login failed.");
            }

            return Redirect($"http://localhost:5173/google-callback?accessToken={result.Data.AccessToken}&refreshToken={result.Data.RefreshToken}");
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authorizationService.LogoutAsync();
            return Ok("Successfully logged out.");
        }
    }
}

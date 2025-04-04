
using Common.Enum;
using Common.Helpers;
using Common.Response;
using Domain.Entity.User;
using Dto.AuthorizationDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Service.JWTService;
using System.Security.Claims;

namespace Service.AuthorizationService
{
    public class AuthorizationService 
    {
        private readonly JwtService _jwtService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthorizationService(UserManager<User> userManager, SignInManager<User> signInManager, JwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        public async Task<AuthResponse> LoginAsync(string usernameOrEmail, string password)
        {
            var user = await _userManager.FindByNameAsync(usernameOrEmail)
                ?? await _userManager.FindByEmailAsync(usernameOrEmail);

            if (user == null)
            {
                return new AuthResponse
                {
                    StatusCode = MyStatusCode.Unauthorized,
                    AuthStatus = AuthStatus.UserNotFound,
                    Description = "User not found",
                    Data = null,
                };
            }

            var passwordIsCorrect = await _userManager.CheckPasswordAsync(user, password);
            if (!passwordIsCorrect)
            {
                return new AuthResponse
                {
                    StatusCode = MyStatusCode.Unauthorized,
                    AuthStatus = AuthStatus.IncorrectPassword,
                    Description = "Password incorrect",
                    Data = null
                };
            }

            var accessToken = await _jwtService.GenerateJwtToken(user);
            var refreshToken = _jwtService.GenerateRefreshToken();

            return new AuthResponse 
            {
                StatusCode = MyStatusCode.OK,
                AuthStatus = AuthStatus.AuthSuccess,
                Description = "Authorization is correct",
                Data = new TokensDto
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                }
            };
        }

        public async Task<AuthResponse> RegisterAsync(RegisterDto registerDto)
        {
            var existingUserByName = await _userManager.FindByNameAsync(registerDto.UserName);
            if (existingUserByName != null)
            {
                return new AuthResponse
                {
                    StatusCode = MyStatusCode.Unauthorized,
                    AuthStatus = AuthStatus.UsernameIsTaken,
                    Description = "Username already taken.",
                    Data = null
                };
            }

            var existingUserByEmail = await _userManager.FindByEmailAsync(registerDto.UserEmail);
            if (existingUserByEmail != null)
            {
                return new AuthResponse
                {
                    StatusCode = MyStatusCode.Unauthorized,
                    AuthStatus = AuthStatus.EmailIsAlredyRegister,
                    Description = "Email already registered.",
                    Data = null
                };
            }

            var user = new User()
            {
                UserName = registerDto.UserName,
                Email = registerDto.UserEmail,
                NativeLanguage = registerDto.NativeLanguage,
                //TODO: target and level target
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                return new AuthResponse
                {
                    StatusCode = MyStatusCode.Unauthorized,
                    AuthStatus = AuthStatus.IncorrectPassword,
                    Description =  "Password is so simple",
                    Data = null
                };
            }

            await _userManager.AddToRoleAsync(user, "User");
            
            var accessToken = await _jwtService.GenerateJwtToken(user);
            var refreshToken = _jwtService.GenerateRefreshToken();

            return new AuthResponse
            {
                StatusCode = MyStatusCode.OK,
                AuthStatus = AuthStatus.AuthSuccess,
                Description = "Register success",
                Data = new TokensDto
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                }
            };
        }

        public async Task<AuthResponse> RefreshTokenAsync(string accessToken, string refreshToken)
        {
            try
            {
                var (newAccessToken, newRefreshToken) = await _jwtService.RefreshToken(accessToken, refreshToken);

                return new AuthResponse
                {
                    StatusCode = MyStatusCode.OK,
                    Description = "Token refresh is success",
                    AuthStatus = AuthStatus.TokenRefreshSuccess,
                    Data = new TokensDto
                    {
                        AccessToken = newAccessToken,
                        RefreshToken = newRefreshToken
                    }
                };
            }
            catch (SecurityTokenException ex)
            {
                return new AuthResponse
                {
                    StatusCode = MyStatusCode.Unauthorized,
                    AuthStatus = AuthStatus.TokenRefreshFailed,
                    Description = ex.Message,
                    Data = null
                };
            }
        }

        public async Task<SignInResult> ExternalLoginAsync()
        {
            var loginInfo = await _signInManager.GetExternalLoginInfoAsync();

            var user = await _userManager.FindByEmailAsync(loginInfo.Principal.FindFirstValue(ClaimTypes.Email)!);

            if (user == null)
            {
                user = new User
                {
                    UserName = loginInfo.Principal.FindFirstValue(ClaimTypes.Name),
                    Email = loginInfo.Principal?.FindFirstValue(ClaimTypes.Email),
                    EmailConfirmed = true
                };

                var createNewUser = await _userManager.CreateAsync(user);

                if (!createNewUser.Succeeded)
                {
                    return SignInResult.Failed;
                }
            }


            var signInResult = await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, isPersistent: false);

            if (!signInResult.Succeeded)
            {
                return SignInResult.Failed;
            }

            return signInResult;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

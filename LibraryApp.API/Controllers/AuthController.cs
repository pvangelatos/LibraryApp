using FluentValidation;
using LibraryApp.Application.DTOs.Auth;
using LibraryApp.Application.Interfaces;
using LibraryApp.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IValidator<RegisterDto> _registerValidator;
        private readonly IValidator<LoginDto> _loginValidator;

        public AuthController(IAuthService authService, IValidator<RegisterDto> registerValidator, IValidator<LoginDto> loginValidator)
        {
            _authService = authService;
            _registerValidator = registerValidator;
            _loginValidator = loginValidator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var validation = await _registerValidator.ValidateAsync(registerDto);
            if (validation == null)
                return BadRequest("Validation failed"); 

            var result = await _authService.RegisterAsync(registerDto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var validation = await _loginValidator.ValidateAsync(loginDto);
            if (validation == null)
                return BadRequest("Validation failed");

            var result = await _authService.LoginAsync(loginDto);
            return Ok(result);
        }
    }
}


       
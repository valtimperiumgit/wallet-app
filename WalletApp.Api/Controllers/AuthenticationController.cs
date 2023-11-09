using Microsoft.AspNetCore.Mvc;
using WalletApp.Api.Abstractions;
using WalletApp.Application.Services;
using WalletApp.Contracts.Authentication;

namespace WalletApp.Api.Controllers;

[Route("authentication")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("registration")]
    public async Task<IActionResult> Registration(RegistrationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var response = await _authenticationService.Registration(request);
        return Ok(response); 
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var response = await _authenticationService.Login(request);
        return Ok(response); 
    }
}
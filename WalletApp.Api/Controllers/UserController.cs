using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Api.Abstractions;
using WalletApp.Application.Services;

namespace WalletApp.Api.Controllers;

[Authorize]
[Route("api/user")]
public class UserController : ApiController
{
    private readonly ICardService _cardService;
    private readonly IUserService _userService;

    public UserController(ICardService cardService, IUserService userService)
    {
        _cardService = cardService;
        _userService = userService;
    }

    [HttpGet("balance")]
    public async Task<IActionResult> CalculateBalance()
    {
        var response = await _cardService.CalculateBalance(GetUserIdFromToken());
        return Ok(response);
    }
    
    [HttpGet("daily-points")]
    public IActionResult CalculateDailyPoints()
    {
        var response = _userService.CalculateDailyPoints();
        return Ok(response);
    }
}
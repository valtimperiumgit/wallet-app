using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Api.Abstractions;
using WalletApp.Application.Services;
using WalletApp.Domain.Core.Abstractions;

namespace WalletApp.Api.Controllers;

[Authorize]
[Route("api/transactions")]
public class TransactionsController : ApiController
{
    private readonly ITransactionsService _transactionsService;

    public TransactionsController(ITransactionsService transactionsService)
    {
        _transactionsService = transactionsService;
    }
    
    [HttpPost]
    public async Task<IActionResult> GetTransactions([FromBody] PaginationAndOrdering paginationAndOrdering)
    {
        return Ok(await _transactionsService.GetTransactions(GetUserIdFromToken(), paginationAndOrdering));
    }
    
    [HttpGet("{transactionId:guid}")]
    public async Task<IActionResult> GetTransactionDetails(Guid transactionId)
    {
        return Ok(await _transactionsService.GetTransactionDetails(GetUserIdFromToken(), transactionId));
    }
}
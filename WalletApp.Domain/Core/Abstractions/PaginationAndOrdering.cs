namespace WalletApp.Domain.Core.Abstractions;

public class PaginationAndOrdering : Pagination
{
    public bool Ascending { get; set; } = true;
}
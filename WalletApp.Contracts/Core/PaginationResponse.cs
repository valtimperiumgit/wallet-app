namespace WalletApp.Contracts.Core;

public class PaginationResponse<T>
{
    public List<T> Items { get; set; }
    
    public int TotalItems { get; set; }
    
    public int CurrentPage { get; set; }
    
    public int PageSize { get; set; }
}
namespace MES.Application.QueryParameters;

public class PaginationParameters
{
    private const int MaxPageSize = 50;
    private int _pageSize = 10;

    public int PageNumber { get; set; } = 1; // stranica koju klijent trazi

    public int PageSize // broj elemenata po stranici
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value; // zastita
    }

    public string? SortBy { get; set; } // polje po kome se sortira
    public bool SortDescending { get; set; } = false; // difolt: rastuce
}

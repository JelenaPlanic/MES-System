

namespace MES.Application.QueryParameters
{
    public class PagedResult<T> // generic class, T - placeholder za entitete
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();  // lista za jednu stranicu
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    }
}

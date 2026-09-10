
namespace MES.Application.DTOs
{
    public class ProductDto // za citanje
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double CycleTimeSeconds { get; set; }
    }
}

using MES.Domain.Entities;

namespace MES.Application.Interfaces
{
    // servis je skoro pass through,(proslednik ) skoro identican sa IGenericRepo<T>
    public interface IProductServise // sta servis treba da radi, bez detalja
    {
        Task<IEnumerable<Product>> GetAllAsync(); // vraca sve proizvode
        Task<Product?> GetByIdAsync(int id); // vraca 1 proizvod ili null
        Task<Product> CreateAsync(Product product); // prima novi, vraca popunjen sa ID
        Task UpdateAsync(Product product); // azurira postojeci, ne vraca nista 
        Task DeleteAsync(int id); // brise po ID
    }

    // sloj opravdan ili suvisan?
}

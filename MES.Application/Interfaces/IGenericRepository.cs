using MES.Domain.Common;


namespace MES.Application.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity // placeholder za tip
    {
        Task<T?> GetByIdAsync(int id); // entitet / null
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity); // nije async, markiranje ent u memoriji kao izmenjen
        void Delete(T entity); // markiranje ent u memoriji kao obrisan
    }
}

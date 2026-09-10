using MES.Domain.Common;
using System.Linq.Expressions;


namespace MES.Application.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity // placeholder za tip
    {
        Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes); // entitet / null
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task AddAsync(T entity);
        void Update(T entity); // nije async, markiranje ent u memoriji kao izmenjen
        void Delete(T entity); // markiranje ent u memoriji kao obrisan
    }
}

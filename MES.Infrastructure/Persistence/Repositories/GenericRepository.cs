using MES.Application.Interfaces;
using MES.Domain.Common;
using Microsoft.EntityFrameworkCore;


namespace MES.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity); // markira novi objekat, fizicki nije u bazi

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
       
        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id); // prvo provera u mem pa posle u bazi
       
        public void Update(T entity) => _dbSet.Update(entity); // menja stanje u mem

        public void Delete(T entity) => _dbSet.Remove(entity);  // priprema promenu

    }
}

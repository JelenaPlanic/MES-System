
using MES.Application.Interfaces;
using MES.Domain.Entities;

namespace MES.Application.Services
{
    public class ProductService: IProductServise
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() // cist pass-through
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task<Product?> GetByIdAsync(int id) // cist pass-through
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _unitOfWork.Products.AddAsync(product); // markira objekat za dodavanje, u memoriji)
            await _unitOfWork.SaveChangesAsync(); // salje INSERT u bazu
            return product;
        }

        public async Task UpdateAsync(Product product)
        {
             _unitOfWork.Products.Update(product); // nije async (menja samo stanje u memoriji),
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id); // prvo ucitamo objekat
            if (product is not null) // zaštita — ako ID ne postoji u bazi, ništa se ne dešava (ne pucamo grešku).
            {
                _unitOfWork.Products.Delete(product);
                await _unitOfWork.SaveChangesAsync();
            }

        }

        

        

       
    }
}

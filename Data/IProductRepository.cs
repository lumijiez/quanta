using System.Collections.Generic;
using System.Threading.Tasks;
using Quanta.Models;

namespace Quanta.Data;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> FindByIdAsync(int id);
    Task<Product?> FindByProductCodeAsync(string productCode);
    Task<IEnumerable<Product>> FindByPriceRangeAsync(decimal minPrice, decimal maxPrice);
    Task<IEnumerable<Product>> FindByIdRangeAsync(int minId, int maxId);
    Task<IEnumerable<Product>> FindByCategoryAsync(string category);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task RemoveAsync(int id);
}
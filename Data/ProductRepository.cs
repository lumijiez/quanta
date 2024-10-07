using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quanta.Models;

namespace Quanta.Data;

public class ProductRepository(QContext context) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await context.Products.ToListAsync();
    }
    
    public async Task<Product?> FindByIdAsync(int id)
    {
        return await context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product?> FindByProductCodeAsync(string productCode)
    {
        return await context.Products.FirstOrDefaultAsync(p => p.ProductCode == productCode);
    }
    
    public async Task<IEnumerable<Product>> FindByPriceRangeAsync(decimal minPrice, decimal maxPrice)
    {
        return await context.Products
            .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> FindByIdRangeAsync(int minId, int maxId)
    {
        return await context.Products
            .Where(p => p.Id >= minId && p.Id <= maxId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> FindByCategoryAsync(string category)
    {
        return await context.Products
            .Where(p => p.Category == category)
            .ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(Product product)
    {
        var existingProduct = await FindByIdAsync(product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.ProductCode = product.ProductCode;
            existingProduct.Category = product.Category;
            existingProduct.Price = product.Price;

            await context.SaveChangesAsync();
        }
    }
    
    public async Task RemoveAsync(int id)
    {
        var product = await FindByIdAsync(id);
        if (product != null)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}

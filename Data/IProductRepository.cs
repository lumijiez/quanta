using System.Collections.Generic;
using Quanta.Models;

namespace Quanta.Data;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    
    Product? FindById(int id);
    
    Product? FindByProductCode(string productCode);
    
    IEnumerable<Product> FindByPriceRange(decimal minPrice, decimal maxPrice);
    
    IEnumerable<Product> FindByCategory(string category);
    
    void Add(Product product);
    
    void Update(Product product);
    
    void Remove(int id);
}
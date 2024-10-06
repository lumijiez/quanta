using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Quanta.Models;

namespace Quanta.Data;

public class ProductRepository(QContext context) : IProductRepository 
{
    public IEnumerable<Product> GetAll()
    {
        return context.Products.ToList();
    }
    
    public Product? FindById(int id)
    {
        return context.Products.FirstOrDefault(p => p.Id == id);
    }

    public Product? FindByProductCode(string productCode)
    {
        return context.Products.FirstOrDefault(p => p.ProductCode == productCode);
    }

    public IEnumerable<Product> FindByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return context.Products
            .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
            .ToList(); 
    }

    public IEnumerable<Product> FindByCategory(string category)
    {
        return context.Products
            .Where(p => p.Category == category)
            .ToList();
    }

    public void Add(Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();
    }

    public void Update(Product product)
    {
        var existingProduct = FindById(product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.ProductCode = product.ProductCode;
            existingProduct.Category = product.Category;
            existingProduct.Price = product.Price;
        }

        context.SaveChanges(); 
    }

    public void Remove(int id)
    {
        var product = FindById(id);
        if (product != null) context.Products.Remove(product);
        context.SaveChanges();
    }
}

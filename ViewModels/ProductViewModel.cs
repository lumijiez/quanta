using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quanta.Data;
using Quanta.Models;
using Quanta.Services;

namespace Quanta.ViewModels;

public class ProductViewModel : ViewModelBase
{
    public ObservableCollection<Product> Products { get; set; } = [];
    public IProductRepository ProductRepository { get; set; }
    
    public ProductViewModel()
    {
        ProductRepository = ServiceLocator.ServiceProvider.GetRequiredService<IProductRepository>();
        _ = LoadProductsAsync();
    }

    private async Task LoadProductsAsync()
    {
        var products = ProductRepository.GetAll();
        foreach (var product in products)
        {
            Products.Add(product);
        }
    }
}
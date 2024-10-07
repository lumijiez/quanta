using Microsoft.Extensions.DependencyInjection;
using Quanta.Aggregates;
using Quanta.Data;
using Quanta.ViewModels;

namespace Quanta.Services;

public static class ServiceCollectionExtensions {
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddDbContext<QContext>();
        
        collection.AddSingleton<IProductRepository, ProductRepository>();
        
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddSingleton<ProductsPageViewModel>();
        collection.AddSingleton<HomePageViewModel>();
        
        collection.AddTransient<ProductViewModel>();
        
        collection.AddSingleton<MainPageAggregator>();
    }
}
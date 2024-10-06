using Microsoft.Extensions.DependencyInjection;
using Quanta.Data;
using Quanta.ViewModels;

namespace Quanta.Services;

public static class ServiceCollectionExtensions {
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddDbContext<QContext>();
        collection.AddSingleton<IProductRepository, ProductRepository>();
        collection.AddTransient<MainWindowViewModel>();

        collection.AddTransient<ProductViewModel>();
    }
}
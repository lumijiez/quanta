using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Quanta.ViewModels;

namespace Quanta.Aggregates;

public class MainPageAggregator(HomePageViewModel homePageViewModel, ProductsPageViewModel productsPageViewModel)
{
    public HomePageViewModel HomePage { get; private set; } = homePageViewModel;
    public ProductsPageViewModel ProductsPage { get; private set; } = productsPageViewModel;
}
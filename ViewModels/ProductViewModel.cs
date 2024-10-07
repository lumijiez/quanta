using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DynamicData;
using Quanta.Data;
using Quanta.Models;
using ReactiveUI;

namespace Quanta.ViewModels;

public class ProductViewModel : ViewModelBase
{
    public ProductViewModel() {}
    
    public ProductViewModel(IProductRepository productRepository)
    {
        ProductRepository = productRepository;
    }
    
    public ObservableCollection<Product> Products { get; set; } = [];
    private IProductRepository ProductRepository { get; set; } = null!;
    
    private bool _isBusy = false;

    public bool IsBusy
    {
        get => _isBusy;
        set => this.RaiseAndSetIfChanged(ref _isBusy, value);
    }
    
    public async Task LoadProductsAsync()
    {
        IsBusy = true;
        Products.Clear();
        var products = await Task.Run(() => ProductRepository.FindByIdRangeAsync(1, 1000));
        foreach (var product in products) Products.Add(product); 
        IsBusy = false;
    }
}
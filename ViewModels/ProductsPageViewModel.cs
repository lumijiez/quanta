using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Quanta.Views;
using ReactiveUI;

namespace Quanta.ViewModels;

public class ProductsPageViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit>? RefreshListCommand { get; set; }
    
    private ProductViewModel _productView = null!;
    
    #region Public Constructor
    
    public ProductsPageViewModel()
    {
    }
    
    #endregion

    #region DI Constructor

    public ProductsPageViewModel(ProductViewModel productViewModel)
    {
        RefreshListCommand = ReactiveCommand.CreateFromTask(async () => await ProductView.LoadProductsAsync(), Observable.Return(true));
        
        _productView = productViewModel;
        ProductView = _productView;
    }

    #endregion
    
    public ProductViewModel ProductView
    {
        get => _productView;
        set => this.RaiseAndSetIfChanged(ref _productView, value);
    }
}
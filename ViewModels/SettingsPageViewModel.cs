using ReactiveUI;

namespace Quanta.ViewModels;

public class SettingsPageViewModel : ViewModelBase
{
    private object _productView;
    public SettingsPageViewModel()
    {
        _productView = new ProductViewModel();
        ProductView = _productView;
    }

    public object ProductView
    {
        get => _productView;
        set => this.RaiseAndSetIfChanged(ref _productView, value);
    }
}
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Quanta.Services;
using Quanta.ViewModels;
using Quanta.Views;

namespace Quanta;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddCommonServices();
        var serviceProvider = serviceCollection.BuildServiceProvider();
        
        var vm = serviceProvider.GetRequiredService<MainWindowViewModel>();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow()
            {
                DataContext = vm
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
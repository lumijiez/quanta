using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Quanta.Aggregates;
using ReactiveUI;

namespace Quanta.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
        private ViewModelBase _currentPage;
        private MainPageAggregator Pages { get; }
        
        #region Commands
        public ICommand NavigateProductsCommand { get; }
        public ReactiveCommand<Unit, Unit> NavigateHomeCommand { get; }
        
        #endregion
        
        public MainWindowViewModel(MainPageAggregator pages)
        {
            Pages = pages;
            _currentPage = Pages.HomePage;
            CurrentPage = Pages.HomePage;
            
            NavigateHomeCommand = ReactiveCommand.Create(() => { CurrentPage = Pages.HomePage; });
            NavigateProductsCommand = ReactiveCommand.Create(async () => await SwitchToProducts());
        }

        private async Task SwitchToProducts()
        {
            CurrentPage = Pages.ProductsPage;
            await Pages.ProductsPage.ProductView.LoadProductsAsync();
        }

        public ViewModelBase CurrentPage
        {
            get => _currentPage;
            set => this.RaiseAndSetIfChanged(ref _currentPage, value);
        }
    }
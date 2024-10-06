using System.Windows.Input;
using ReactiveUI;

namespace Quanta.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
        public ICommand NavigateSettingsCommand { get; }
        public ICommand NavigateHomeCommand { get; }

        public ViewModelBase SettingsViewModel { get; } = new SettingsPageViewModel();
        public ViewModelBase HomeViewModel { get; } = new HomePageViewModel();
        
        public MainWindowViewModel()
        {
            _currentPage = HomeViewModel;
            CurrentPage = HomeViewModel;

            NavigateHomeCommand = ReactiveCommand.Create(() => { CurrentPage = HomeViewModel; });
            NavigateSettingsCommand = ReactiveCommand.Create(() => { CurrentPage = SettingsViewModel; });
        }
        
        private ViewModelBase _currentPage;

        public ViewModelBase CurrentPage
        {
            get => _currentPage;
            set => this.RaiseAndSetIfChanged(ref _currentPage, value);
        }
    }
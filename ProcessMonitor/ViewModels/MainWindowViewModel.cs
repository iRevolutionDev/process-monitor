using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ProcessMonitor.Views.Pages;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace ProcessMonitor.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private bool _isInitialized;
    [ObservableProperty] private ObservableCollection<MenuItem> _menuItems = new();
    [ObservableProperty] private ObservableCollection<object> _pages = new();

    [ObservableProperty] private string _windowTitle = string.Empty;

    public MainWindowViewModel(INavigationService navigationService)
    {
        if (!_isInitialized)
            InitializeViewModel();
    }

    private void InitializeViewModel()
    {
        WindowTitle = "Process Monitor";
        Pages = new ObservableCollection<object>
        {
            new NavigationViewItem
            {
                Content = "Processes",
                Icon = new SymbolIcon { Symbol = SymbolRegular.BroadActivityFeed24 },
                TargetPageType = typeof(ProcessesPage)
            }
        };

        MenuItems = new ObservableCollection<MenuItem>
        {
            new()
            {
                Header = "Processes",
                Tag = "tray_process"
            }
        };

        _isInitialized = true;
    }
}
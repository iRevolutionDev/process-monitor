using System;
using ProcessMonitor.ViewModels;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace ProcessMonitor.Views;

public partial class MainWindow : INavigationWindow
{
    public MainWindow(MainWindowViewModel viewModel, IPageService pageService, INavigationService navigationService)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();

        SetPageService(pageService);
        navigationService.SetNavigationControl(RootNavigation);
    }

    public MainWindowViewModel ViewModel { get; }

    public INavigationView GetNavigation()
    {
        return RootNavigation;
    }

    public bool Navigate(Type pageType)
    {
        return RootNavigation.Navigate(pageType);
    }

    public void SetServiceProvider(IServiceProvider serviceProvider)
    {
        throw new NotImplementedException();
    }

    public void SetPageService(IPageService pageService)
    {
        RootNavigation.SetPageService(pageService);
    }

    public void ShowWindow()
    {
        Show();
    }

    public void CloseWindow()
    {
        Close();
    }
}
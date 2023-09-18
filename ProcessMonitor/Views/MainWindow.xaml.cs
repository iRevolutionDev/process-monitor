using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace ProcessMonitor.Views;

public partial class MainWindow : INavigationWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public INavigationView GetNavigation()
    {
        throw new NotImplementedException();
    }

    public bool Navigate(Type pageType)
    {
        throw new NotImplementedException();
    }

    public void SetServiceProvider(IServiceProvider serviceProvider)
    {
        throw new NotImplementedException();
    }

    public void SetPageService(IPageService pageService)
    {
        throw new NotImplementedException();
    }

    public void ShowWindow()
    {
        throw new NotImplementedException();
    }

    public void CloseWindow()
    {
        throw new NotImplementedException();
    }
}
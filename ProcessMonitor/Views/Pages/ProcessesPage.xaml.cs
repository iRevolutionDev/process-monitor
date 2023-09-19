using ProcessMonitor.ViewModels;
using Wpf.Ui.Controls;

namespace ProcessMonitor.Views.Pages;

/// <summary>
///     Interaction logic for ProcessesPage.xaml
/// </summary>
public partial class ProcessesPage : INavigableView<ProcessesViewModel>
{
    public ProcessesPage(ProcessesViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }

    public ProcessesViewModel ViewModel { get; }
}
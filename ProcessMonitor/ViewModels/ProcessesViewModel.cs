using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Wpf.Ui.Controls;

namespace ProcessMonitor.ViewModels;

public partial class ProcessesViewModel : ObservableObject, INavigationAware
{
    private bool _isInitialized;

    [ObservableProperty] private List<Process> _processes = new();

    public void OnNavigatedTo()
    {
        if (!_isInitialized)
            InitializeViewModel();
    }

    public void OnNavigatedFrom()
    {
    }

    private void UpdateProcesses()
    {
        Processes = Process.GetProcesses().ToList();
    }

    private void InitializeViewModel()
    {
        UpdateProcesses();

        _isInitialized = true;
    }
}
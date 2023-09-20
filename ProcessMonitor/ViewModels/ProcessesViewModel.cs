using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using ProcessMonitor.Models;
using Wpf.Ui.Controls;

namespace ProcessMonitor.ViewModels;

public partial class ProcessesViewModel : ObservableObject, INavigationAware
{
    [ObservableProperty] private bool _handles;
    [ObservableProperty] private bool _id;
    private bool _isInitialized;

    // Columns
    [ObservableProperty] private bool _name;

    [ObservableProperty] private ObservableCollection<ProcessItem> _processes = new();
    [ObservableProperty] private ProcessItem? _selectedProcess;
    [ObservableProperty] private bool _threads;

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
        var processes = Process.GetProcesses().OrderBy(p => p.ProcessName).ToList();

        Processes.Clear();

        foreach (var process in processes)
            Processes.Add(new ProcessItem(process));
    }

    private void InitializeViewModel()
    {
        UpdateProcesses();

        Name = true;
        Id = true;
        Threads = true;

        _isInitialized = true;
    }
}
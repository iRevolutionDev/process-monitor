using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProcessMonitor.Models;
using Wpf.Ui.Controls;

namespace ProcessMonitor.ViewModels;

public partial class ProcessesViewModel : ObservableObject, INavigationAware
{
    private readonly object _updateLock = new();

    [ObservableProperty] private ObservableCollection<MenuItem> _contextMenuItems = new();
    [ObservableProperty] private bool _handles;
    [ObservableProperty] private bool _id;
    private bool _isInitialized;
    [ObservableProperty] private bool _isProcessSelected;

    [ObservableProperty] private ObservableCollection<SystemProcess> _processes = new();
    [ObservableProperty] private SystemProcess? _selectedProcess;

    private Thread? _updateThread;

    private ICommand KillProcessCommand { get; } = new RelayCommand<SystemProcess>(KillProcess);
    public ICommand SelectedProcessCommand { get; } = new RelayCommand<SystemProcess>(SelectProcess);

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
            Processes.Add(new SystemProcess(process));
    }

    private void InitializeViewModel()
    {
        BindingOperations.EnableCollectionSynchronization(Processes, _updateLock);

        UpdateProcesses();

        _updateThread = new Thread(() =>
        {
            while (true)
            {
                Thread.Sleep(1000);
                Dispatcher.CurrentDispatcher.Invoke(UpdateProcesses);
            }
        });

        _updateThread.Start(); // TODO: Dispose thread

        ContextMenuItems = new ObservableCollection<MenuItem>
        {
            new()
            {
                Header = "Kill",
                Command = KillProcessCommand,
                CommandParameter = SelectedProcess
            }
        };

        _isInitialized = true;
    }

    private static void KillProcess(SystemProcess? process)
    {
        Console.WriteLine(process?.Name);
        process?.Kill();
    }

    private static void SelectProcess(SystemProcess? process)
    {
        Console.WriteLine(process?.Name);
    }
}
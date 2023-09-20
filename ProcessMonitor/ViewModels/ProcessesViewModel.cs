using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Data;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using ProcessMonitor.Models;
using Wpf.Ui.Controls;

namespace ProcessMonitor.ViewModels;

public partial class ProcessesViewModel : ObservableObject, INavigationAware
{
    private static readonly object _updateLock = new();
    [ObservableProperty] private bool _handles;
    [ObservableProperty] private bool _id;
    private bool _isInitialized;

    [ObservableProperty] private ObservableCollection<SystemProcess> _processes = new();
    [ObservableProperty] private SystemProcess? _selectedProcess;

    private Thread? _updateThread;

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

        _isInitialized = true;
    }
}
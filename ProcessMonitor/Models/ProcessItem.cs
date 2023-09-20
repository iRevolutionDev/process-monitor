using System.Diagnostics;

namespace ProcessMonitor.Models;

public class ProcessItem
{
    public ProcessItem(Process process)
    {
        Process = process;
    }

    private Process Process { get; }

    public string Name => Process.ProcessName;
    public int Id => Process.Id;
}
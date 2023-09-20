using System.Diagnostics;

namespace ProcessMonitor.Models;

public class SystemProcess
{
    public SystemProcess(Process process)
    {
        Process = process;
    }

    private Process Process { get; }

    public string Name => Process.ProcessName;
    public int Id => Process.Id;
}
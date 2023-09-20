using System.Diagnostics;

namespace ProcessMonitor.Models;

public class SystemProcess : Process
{
    public SystemProcess(Process process)
    {
        Process = process;
    }

    private Process Process { get; }

    public string Name => Process.ProcessName;
    public new int Id => Process.Id;

    public new void Kill()
    {
        Process.Kill();
    }
}
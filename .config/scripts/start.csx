using System.Diagnostics;
using System.Diagnostics;
using System.Runtime.InteropServices;

Process Run(string name, string command, string cwd)
{
    var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    var shell = isWindows ? "cmd" : "/bin/bash";
    var args = isWindows ? $"/c {command}" : $"-c \"{command}\"";

    var p = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = shell,
            Arguments = args,
            WorkingDirectory = cwd,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        },
    };

    p.OutputDataReceived += (_, e) =>
    {
        if (e.Data != null)
            Console.WriteLine($"[{name}] {e.Data}");
    };

    p.ErrorDataReceived += (_, e) =>
    {
        if (e.Data != null)
            Console.WriteLine($"[{name} ERROR] {e.Data}");
    };

    p.Start();
    p.BeginOutputReadLine();
    p.BeginErrorReadLine();

    return p;
}

// FRONTEND
var frontend = Run("VUE", "npm run dev", "src/OnboardingClient");

// BACKEND
var backend = Run("DOTNET", "dotnet watch run", "src/OnboardingClient.Api");

Console.WriteLine("🚀 Frontend + Backend running (CTRL+C to stop)");

Console.CancelKeyPress += (_, _) =>
{
    frontend.Kill(true);
    backend.Kill(true);
};

await Task.Delay(-1);

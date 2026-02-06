using System.Diagnostics;
using System.Runtime.InteropServices;

var args = Environment.GetCommandLineArgs();

var brokerId = args.Length > 2 ? args[2] : "";

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
var frontendCmd = brokerId == "" ? "npm run dev" : $"VITE_MODE={brokerId} npm run dev";
var frontend = Run("VUE", frontendCmd, "src/OnboardingClient");

// BACKEND
var backendCmd = brokerId == "" ? "dotnet watch run" : $"dotnet watch run --environment {brokerId}";
var backend = Run("DOTNET", backendCmd, "src/OnboardingClient.Api");

Console.WriteLine("🚀 Frontend + Backend running (CTRL+C to stop)");

Console.CancelKeyPress += (_, _) =>
{
    frontend.Kill(true);
    backend.Kill(true);
};

await Task.Delay(-1);

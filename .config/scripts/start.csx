using System.Diagnostics;

Process Run(string name, string command, string cwd)
{
    var p = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "cmd",
            Arguments = $"/c {command}",
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

using System.Diagnostics;

var args = Environment.GetCommandLineArgs();

var brokerId = args.Length > 2 ? args[2] : "";

int Run(string name, string command, string cwd)
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
    p.WaitForExit();

    return p.ExitCode;
}

var root = Directory.GetCurrentDirectory();
var buildDir = Path.Combine(root, "dist");
var frontendOut = Path.Combine(buildDir, "frontend");
var backendOut = Path.Combine(buildDir, "backend");

// clean build folder
if (Directory.Exists(buildDir))
    Directory.Delete(buildDir, true);

Directory.CreateDirectory(frontendOut);
Directory.CreateDirectory(backendOut);

Console.WriteLine("📦 Build directory prepared");

// =====================
// FRONTEND
// =====================
Console.WriteLine("🏗️ Building frontend...");

var frontendCmd = brokerId != "" ? $"VITE_MODE={brokerId} npm run build" : "npm run build";
Console.WriteLine($"VITE_MODE={frontendCmd}");
if (Run("VUE", frontendCmd, "src/OnboardingClient") != 0)
    throw new Exception("❌ Frontend build failed");

// copy dist → build/frontend
var distPath = Path.Combine(root, "src", "OnboardingClient", "dist");

if (!Directory.Exists(distPath))
    throw new Exception("❌ Frontend dist folder not found");

CopyDirectory(distPath, frontendOut);

Console.WriteLine("✅ Frontend build done");

// =====================
// BACKEND
// =====================
Console.WriteLine("🏗️ Publishing backend...");

if (Run("API", $"dotnet publish -c Release -o \"{backendOut}\"", "src/OnboardingClient.Api") != 0)
{
    throw new Exception("❌ Backend publish failed");
}

Console.WriteLine("✅ Backend publish done");
Console.WriteLine("🎉 COMPILE SUCCESS");

// =====================
// HELPERS
// =====================
static void CopyDirectory(string sourceDir, string targetDir)
{
    foreach (var dir in Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories))
        Directory.CreateDirectory(dir.Replace(sourceDir, targetDir));

    foreach (var file in Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories))
        File.Copy(file, file.Replace(sourceDir, targetDir), true);
}

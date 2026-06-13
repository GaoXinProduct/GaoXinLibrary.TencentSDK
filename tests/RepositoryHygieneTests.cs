using System.Diagnostics;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class RepositoryHygieneTests
{
    [Fact]
    public async Task SrcBuildArtifacts_AreIgnoredAndNotTracked()
    {
        var root = TestRepository.FindRoot();
        var gitignore = await File.ReadAllTextAsync(Path.Combine(root, ".gitignore"));

        Assert.Contains("/src/bin/", gitignore);
        Assert.Contains("/src/obj/", gitignore);

        if (!Directory.Exists(Path.Combine(root, ".git")))
            return;

        var output = await RunGitAsync(root, "ls-files", "src/bin", "src/obj");
        Assert.True(string.IsNullOrWhiteSpace(output), $"src build artifacts are tracked:{Environment.NewLine}{output}");
    }

    private static async Task<string> RunGitAsync(string root, params string[] arguments)
    {
        using var process = new Process();
        process.StartInfo = new ProcessStartInfo("git")
        {
            WorkingDirectory = root,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        };

        foreach (var argument in arguments)
            process.StartInfo.ArgumentList.Add(argument);

        process.Start();
        var output = await process.StandardOutput.ReadToEndAsync();
        var error = await process.StandardError.ReadToEndAsync();
        await process.WaitForExitAsync();

        Assert.True(process.ExitCode == 0, error);
        return output.Trim();
    }
}

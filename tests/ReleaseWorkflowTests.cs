using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class ReleaseWorkflowTests
{
    [Fact]
    public async Task PublishWorkflow_RunsReleaseTestsBeforePack()
    {
        var workflow = await File.ReadAllTextAsync(Path.Combine(TestRepository.FindRoot(), ".github", "workflows", "publish.yml"));

        var testIndex = workflow.IndexOf("dotnet test", StringComparison.Ordinal);
        var packIndex = workflow.IndexOf("dotnet pack", StringComparison.Ordinal);

        Assert.True(testIndex >= 0, "publish workflow must run dotnet test before publishing");
        Assert.True(packIndex > testIndex, "publish workflow must run tests before dotnet pack");
        Assert.Contains("tests/GaoXinLibrary.TencentSDK.Tests.csproj", workflow);
        Assert.Contains("-c Release", workflow);
    }
}

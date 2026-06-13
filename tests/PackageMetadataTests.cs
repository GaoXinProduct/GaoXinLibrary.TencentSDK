using System.Xml.Linq;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class PackageMetadataTests
{
    [Fact]
    public void ProjectFile_DefinesPackageMetadataAndSymbolSettings()
    {
        var projectPath = Path.Combine(TestRepository.FindRoot(), "src", "GaoXinLibrary.TencentSDK.csproj");
        var document = XDocument.Load(projectPath);

        Assert.Equal("MIT", Value(document, "PackageLicenseExpression"));
        Assert.Equal("true", Value(document, "PublishRepositoryUrl"));
        Assert.Equal("true", Value(document, "EmbedUntrackedSources"));
        Assert.Equal("true", Value(document, "IncludeSymbols"));
        Assert.Equal("snupkg", Value(document, "SymbolPackageFormat"));
        var noWarn = Value(document, "NoWarn");
        Assert.Contains("1591", noWarn);
        Assert.Contains("1570", noWarn);
        Assert.Contains("1572", noWarn);
        Assert.Contains("1573", noWarn);
        Assert.Contains("1574", noWarn);
        Assert.Contains("0618", noWarn);
    }

    private static string? Value(XDocument document, string elementName)
        => document.Descendants(elementName).FirstOrDefault()?.Value;
}

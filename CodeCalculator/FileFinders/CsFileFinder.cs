using System.Collections.Generic;

namespace CodeCalculator.FileFinders;

internal sealed class CsFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            "bin",
            "obj",
            ".vs",
            ".vscode",
            ".idea",
            ".git",
            ".svn",
            ".hg",
            "packages",
            ".nuget",
            "TestResults",
            "BenchmarkDotNet.Artifacts",
            "artifacts",
            "publish",
            "out",
            "dist",
            ".dotnet",
            ".ncrunch",
            ".axoCover"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "project.assets.json",
            "project.nuget.cache",
            "packages.lock.json"
        );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".csproj",
            ".sln",
            ".slnx",
            ".props",
            ".targets",
            ".nuspec",
            ".nupkg",
            ".g.cs",
            ".designer.cs",
            ".generated.cs",
            ".pdb",
            ".mdb",
            ".msi",
            ".cab"
        );
}

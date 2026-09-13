#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class VisualBasicFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vs",
        ".vscode",
        ".idea",
        "bin",
        "obj",
        "packages",
        "TestResults",
        "artifacts",
        "publish",
        "out",
        "dist",
        ".dotnet",
        ".ncrunch",
        ".axoCover"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "project.assets.json",
        "project.nuget.cache",
        "packages.lock.json"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".vbproj",
            ".sln",
            ".slnx",
            ".props",
            ".targets",
            ".nuspec",
            ".nupkg",
            ".g.vb",
            ".designer.vb",
            ".generated.vb",
            ".pdb",
            ".mdb",
            ".msi",
            ".cab"
        );
}

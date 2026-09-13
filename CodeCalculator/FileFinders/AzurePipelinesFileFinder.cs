#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class AzurePipelinesFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        "node_modules",
        "bin",
        "obj",
        "build",
        "dist",
        "coverage"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set();

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared();
}

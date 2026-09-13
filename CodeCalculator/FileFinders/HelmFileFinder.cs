#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class HelmFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        ".helm",
        "charts",
        "tmp",
        "build",
        "dist"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "Chart.lock"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared();
}

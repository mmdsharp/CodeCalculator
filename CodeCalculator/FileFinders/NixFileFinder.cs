#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class NixFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        ".direnv",
        "result",
        "build",
        "dist"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set();

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared();
}

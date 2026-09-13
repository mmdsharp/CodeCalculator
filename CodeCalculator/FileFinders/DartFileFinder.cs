#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class DartFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".dart_tool",
        ".pub-cache",
        ".pub",
        "build",
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "coverage",
        "node_modules"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "pubspec.lock"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".dill",
            ".snapshot"
        );
}

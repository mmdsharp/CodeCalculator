#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class ZigFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "zig-cache",
        "zig-out",
        "build",
        "dist"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set();

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".o",
            ".a",
            ".so",
            ".dll",
            ".dylib",
            ".exe"
        );
}

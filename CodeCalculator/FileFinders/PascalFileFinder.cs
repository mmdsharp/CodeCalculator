#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class PascalFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "build",
        "bin",
        "lib",
        "obj",
        "dist",
        "Debug",
        "Release"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set();

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".ppu",
            ".o",
            ".a",
            ".so",
            ".dll",
            ".exe"
        );
}

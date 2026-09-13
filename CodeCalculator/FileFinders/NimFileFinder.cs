#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class NimFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "nimcache",
        "build",
        "dist",
        "bin",
        "vendor"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set();

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".c",
            ".o",
            ".obj",
            ".dll",
            ".so",
            ".dylib",
            ".exe"
        );
}

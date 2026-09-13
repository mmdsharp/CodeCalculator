#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class CrystalFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "lib",
        "bin",
        "tmp",
        "build",
        "dist"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "shard.lock"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".so",
            ".dylib",
            ".dll",
            ".o"
        );
}

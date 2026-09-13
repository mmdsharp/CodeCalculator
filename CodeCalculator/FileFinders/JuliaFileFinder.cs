#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class JuliaFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        ".julia",
        ".cache",
        "deps",
        "build",
        "dist"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "Manifest.toml"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".ji",
            ".so",
            ".dll",
            ".dylib"
        );
}

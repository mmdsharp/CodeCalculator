#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class MesonFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "build",
        "builddir",
        "dist",
        "out"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "meson-private"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".o",
            ".obj",
            ".a",
            ".lib",
            ".so",
            ".dll",
            ".dylib",
            ".exe"
        );
}

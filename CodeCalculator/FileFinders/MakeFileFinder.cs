#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class MakeFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "build",
        "Build",
        "bin",
        "obj",
        "out",
        "dist",
        "target",
        "Debug",
        "Release"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set();

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

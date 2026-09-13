#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class LuaFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "node_modules",
        "vendor",
        "build",
        "dist",
        "target",
        ".cache"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set();

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".luac",
            ".so",
            ".dll"
        );
}

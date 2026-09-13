#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class GodotFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".godot",
        ".import",
        ".vscode",
        ".idea",
        "build",
        "dist",
        "export"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set();

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".pck",
            ".godot",
            ".import",
            ".ctex",
            ".stex"
        );
}

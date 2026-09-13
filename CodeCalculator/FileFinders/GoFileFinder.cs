using System.Collections.Generic;

namespace CodeCalculator.FileFinders;

internal sealed class GoFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            "vendor",
            "bin",
            ".cache",
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea",
            "dist",
            "build",
            "out",
            "coverage"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set("go.sum");

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".test",
            ".a"
        );
}

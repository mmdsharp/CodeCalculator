using System.Collections.Generic;

namespace CodeCalculator.FileFinders;

internal sealed class JavaKotlinFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            "target",
            "build",
            "out",
            ".gradle",
            ".mvn",
            ".m2",
            ".idea",
            ".vscode",
            ".settings",
            ".git",
            ".svn",
            ".hg",
            "node_modules"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set("gradle-wrapper.jar");

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".class",
            ".jar",
            ".war",
            ".ear",
            ".jmod",
            ".dex"
        );
}

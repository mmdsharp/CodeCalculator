using System.Collections.Generic;

namespace CodeCalculator.FileFinders;

internal sealed class AndroidFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            "build",
            ".gradle",
            ".mvn",
            ".idea",
            ".vscode",
            ".git",
            ".svn",
            ".hg",
            "captures",
            "release"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "local.properties",
            "gradle-wrapper.jar"
        );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".apk",
            ".aab",
            ".aar",
            ".dex",
            ".class",
            ".jar",
            ".keystore",
            ".jks"
        );
}

#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class ClojureFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        ".cpcache",
        "target",
        "classes",
        "checkouts",
        "node_modules"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "pom.xml"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".class",
            ".jar",
            ".war"
        );
}

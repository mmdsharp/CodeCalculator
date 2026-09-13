#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class GroovyFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        ".gradle",
        "build",
        "out",
        "target",
        "node_modules"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "gradle-wrapper.jar"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".class",
            ".jar",
            ".war",
            ".ear"
        );
}

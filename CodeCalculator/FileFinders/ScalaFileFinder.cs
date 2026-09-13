#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class ScalaFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        ".bloop",
        ".metals",
        ".scala-build",
        "target",
        "project/target",
        "project/project",
        ".gradle",
        "build",
        "out"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "dependency.lock"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".class",
            ".jar",
            ".war",
            ".ear",
            ".sbt"
        );
}

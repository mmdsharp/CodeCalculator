// ErlangFileFinder.cs

namespace CodeCalculator.FileFinders;

internal sealed class ErlangFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            "_build",
            "deps",
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea",
            "ebin",
            "logs"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "rebar.lock"
        );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".beam"
        );
}

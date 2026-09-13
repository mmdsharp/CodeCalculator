#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class HaskellFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        ".stack-work",
        "dist",
        "dist-newstyle",
        ".cabal-sandbox",
        "cabal-dev",
        "target"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "cabal.project.freeze",
        "stack.yaml.lock"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".hi",
            ".dyn_hi",
            ".dyn_o",
            ".o",
            ".prof",
            ".eventlog"
        );
}

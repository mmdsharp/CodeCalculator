#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class RFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        ".Rproj.user",
        "renv/library",
        "packrat/lib",
        "packrat/src",
        "cache",
        "coverage",
        "output"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "renv.lock"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".rds",
            ".rda",
            ".RData",
            ".so",
            ".dll"
        );
}
